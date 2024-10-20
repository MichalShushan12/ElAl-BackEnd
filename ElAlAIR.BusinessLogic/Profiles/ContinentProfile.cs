using AutoMapper;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.BusinessLogic.Profiles
{
    public class ContinentProfile : Profile
    {
        public ContinentProfile() 
        {
            CreateMap<ContinentDTO, Continent>().ReverseMap();
        }
    }
}
