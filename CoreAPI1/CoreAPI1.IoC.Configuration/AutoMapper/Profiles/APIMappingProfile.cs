using AutoMapper;
using DC = CoreAPI1.API.DataContracts;
using S = CoreAPI1.Services.Model;

namespace CoreAPI1.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DC.User, S.User>().ReverseMap();
            CreateMap<DC.Address, S.Address>().ReverseMap();
        }
    }
}
