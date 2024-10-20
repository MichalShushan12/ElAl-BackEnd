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
    public class DestinationProfile : Profile
    {
        public DestinationProfile()
        {
            CreateMap<DestinationDTO, Destination>().ReverseMap();
        }
    }
}
