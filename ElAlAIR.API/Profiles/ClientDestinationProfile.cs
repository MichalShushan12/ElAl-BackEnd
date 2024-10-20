using AutoMapper;
using ElAlAIR.API.Models;
using ElAlAIR.DTO.Models;

namespace ElAlAIR.API.Profiles
{
    public class ClientDestinationProfile : Profile
    {
        public ClientDestinationProfile() 
        {
            CreateMap<CreateDestinationRequest, DestinationDTO>();
        }
    }
}
