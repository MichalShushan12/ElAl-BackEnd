using AutoMapper;
using ElAlAIR.BusinessLogic.Interfaces;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DataAccess.Interfaces;
using ElAlAIR.DataAccess.Repositories;
using ElAlAIR.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.BusinessLogic.Services
{
    public class ContinentService : IContinentService
    {
        private IContinentRepository _continentRepository;
        private IMapper _mapper;

        public ContinentService(IContinentRepository continentRepository, IMapper mapper)
        {
            _continentRepository = continentRepository;
            _mapper = mapper;
        }

        public async Task<List<ContinentDTO>> GetAllContinents()
        {
            try
            {
                List<Continent> continentList = await _continentRepository.GetAllContinents();
                return _mapper.Map<List<ContinentDTO>>(continentList);
            }


            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        public async Task<ContinentDTO> GetContinentById(Guid continentId)
        {
            try
            {
                Continent continent = await _continentRepository.GetContinentById(continentId);
                return _mapper.Map<ContinentDTO>(continent);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }
    }
}
