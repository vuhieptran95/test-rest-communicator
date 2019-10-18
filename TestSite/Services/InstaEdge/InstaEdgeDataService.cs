using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EPiServer.Logging;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TestSite.Exceptions.BusinessExceptions;
using TestSite.RestMessages;

namespace TestSite.Services.InstaEdge
{
    public interface IInstaEdgeDataService
    {

    }

    public class InstaEdgeDataService : IInstaEdgeDataService
    {
        private readonly IRestCommunicator _restCommunicator;

        public InstaEdgeDataService(IRestCommunicator restCommunicator)
        {
            _restCommunicator = restCommunicator;
        }

        public async Task<UnifiedResponse> GetTechnicianAvailibility(string endpoint, TechnicianAvailibilityRequest request, IEnumerable<KeyValuePair<string, string>> headers)
        {
            var response = await _restCommunicator.Post<TechnicianAvailibilityResponse>(
                endpoint,
                request,
                headers
            );
            return response;

        }
    }

    /// <summary>
    /// This RestCommunicator uses Flurl: https://flurl.dev/
    /// </summary>
    public interface IRestCommunicator
    {
        Task<UnifiedResponse> Post<T>(string url, object data, IEnumerable<KeyValuePair<string, string>> headers) where T : RestResponse;
    }

    public class RestCommunicator : IRestCommunicator
    {
        private readonly ILogger _logger = LogManager.GetLogger();
        
        public async Task<UnifiedResponse> Post<T>(string url, object data, IEnumerable<KeyValuePair<string, string>> headers) where T : RestResponse
        {
            var unifiedResponse = new UnifiedResponse();
            try
            {
                var request = url.WithHeaders(headers);
                var dataSerialized = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                    Formatting = Formatting.Indented
                });
                //var request = url.WithHeader("apikey", "46f7-6db8-50ebcd876472").WithHeader("countryheader", "AUS").WithHeader("Content-Type", "application/json");
                var correctResponses = await request.PostStringAsync(dataSerialized).ReceiveJson<IEnumerable<T>>();
                IEnumerable<ErrorResponse> errorResponses = null;

                if (correctResponses == null)
                {
                    errorResponses = await request.PostJsonAsync(data).ReceiveJson<IEnumerable<ErrorResponse>>();
                    throw new BusinessException() { BusinessErrors = errorResponses };
                }

                unifiedResponse.Responses = correctResponses;
            }
            catch (BusinessException ex)
            {
                _logger.Error("BusinessRestException: {0} - Error info: {1}", ex.Message, JsonConvert.SerializeObject(ex.BusinessErrors));
                unifiedResponse.Errors = ex.BusinessErrors;
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseStringAsync();
                _logger.Error("FlurlHttpException: {0} - Error info: {1}", ex.Message, error);
            }
            //catch(Exception ex)
            //{
            //    _logger.Error(ex.Message, ex);
            //    throw;
            //}

            return unifiedResponse;

        }
    }
}