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

        public async Task<UnifiedResponse<TechnicianAvailibilityResponse, ErrorResponse>> GetTechnicianAvailibility(string endpoint, TechnicianAvailibilityRequest request, IEnumerable<KeyValuePair<string, string>> headers)
        {
            var response = await _restCommunicator.Post<TechnicianAvailibilityResponse, ErrorResponse>(
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
        Task<UnifiedResponse<R, E>> Post<R, E>(string url, object data, IEnumerable<KeyValuePair<string, string>> headers) 
            where R : RestResponse
            where E : ErrorResponse;
    }

    public class RestCommunicator : IRestCommunicator
    {
        private readonly ILogger _logger = LogManager.GetLogger();

        public async Task<UnifiedResponse<R, E>> Post<R, E>(string url, object data, IEnumerable<KeyValuePair<string, string>> headers) 
            where R : RestResponse
            where E: ErrorResponse
        {
            var unifiedResponse = new UnifiedResponse<R, E>();
            dynamic rawResponse = null;
            try
            {
                var request = url.WithHeaders(headers);

                var dataSerialized = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                    Formatting = Formatting.Indented
                });
                //var request = url.WithHeader("apikey", "46f7-6db8-50ebcd876472").WithHeader("countryheader", "AUS").WithHeader("Content-Type", "application/json");

                rawResponse = await request.PostStringAsync(dataSerialized).ReceiveString();

                if (typeof(IExpectedArrayResponse).IsAssignableFrom(typeof(R)))
                {
                    IEnumerable<E> errorResponses = JsonConvert.DeserializeObject<IEnumerable<E>>(rawResponse);

                    if (errorResponses != null && errorResponses.Count() > 0 && errorResponses.FirstOrDefault()?.ErrorCode != null)
                    {
                        throw new BusinessException<E>() { BusinessError = errorResponses.FirstOrDefault() };
                    }

                    IEnumerable<R> objectResponses = JsonConvert.DeserializeObject<IEnumerable<R>>(rawResponse);

                    if (objectResponses != null && objectResponses.Count() > 1)
                    {
                        unifiedResponse.Response = objectResponses?.FirstOrDefault();
                    }
                }
                else
                {
                    R objectResponse = JsonConvert.DeserializeObject<R>(rawResponse);
                    if (objectResponse == null)
                    {
                        E errorResponse = JsonConvert.DeserializeObject<E>(rawResponse);
                        throw new BusinessException<E>() { BusinessError = errorResponse };
                    }
                    unifiedResponse.Response = objectResponse;
                }

            }
            catch (BusinessException<E> ex)
            {
                _logger.Error("BusinessRestException: {0} - Error info: {1} - Raw response: {2}", 
                    ex.Message, 
                    JsonConvert.SerializeObject(ex.BusinessError),
                    rawResponse as string);
                unifiedResponse.BusinessError = ex.BusinessError;
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseStringAsync();
                _logger.Error("FlurlHttpException: {0} - Error info: {1} - Raw response: {2}", ex.Message, error, rawResponse as string);
                unifiedResponse.Exception = ex;
            }
            catch (Exception ex)
            {
                _logger.Error("Raw Response: {0}", rawResponse as string);
                _logger.Error(ex.Message, ex);
                unifiedResponse.Exception = ex;
            }

            return unifiedResponse;
        }
    }
}