using AutoMapper;
using ElAlAIR.API.Models;
using ElAlAIR.DTO.Models;

namespace ElAlAIR.API.Profiles
{
    public class ClientContinentProfile : Profile
    {
        public ClientContinentProfile()
        {
            CreateMap<CreateContinentRequest, ContinentDTO>();
        }
    }
}
