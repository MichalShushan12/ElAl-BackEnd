using AutoMapper;
using ElAlAIR.API.Models;
using ElAlAIR.DTO.Models;

namespace ElAlAIR.API.Profiles
{
    public class ClientUserProfile : Profile
    {
        public ClientUserProfile() 
        {
            CreateMap<CreateUserRequest, UserDTO>(); 
            CreateMap<LoginRegisterRequest, UserDTO>();
        }
    }
}
