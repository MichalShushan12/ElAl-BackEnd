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
using static System.Reflection.Metadata.BlobBuilder;


namespace ElAlAIR.BusinessLogic.Services
{
    public class DestinationService : IDestinationService
    {
        private IDestinationRepository _destinationRepository;
        private IMapper _mapper;

        public DestinationService(IDestinationRepository destinationRepository, IMapper mapper)
        {
            _destinationRepository = destinationRepository; 
            _mapper = mapper;
        }

        public async Task<List<DestinationDTO>> GetAllDestinations()
        {
            try
            {
                List<Destination> destination = await _destinationRepository.GetAllDestinations();
                return _mapper.Map<List<DestinationDTO>>(destination);

                //return destination.Select(p => DestinationsMapper.Map(p)).ToList();
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        //public async Task<DestinationDTO> GetDestinationById(Guid destinationId)
        //{
        //    try
        //    {
        //        Destination destination = await _destinationRepository.GetDestinationById(destinationId);
        //        return _mapper.Map<DestinationDTO>(destination);

        //        //return DestinationsMapper.Map(destination);
        //    }

        //    catch (Exception ex)
        //    {
        //        // Handle the exception (e.g., log it)
        //        // You can also consider returning a default or error OrderDTO here
        //        throw new ApplicationException("Error creating order", ex);
        //    }
        //}

        public async Task<DestinationDTO> GetDestinationDetails(string name)
        {
            try
            {
                var dest = await _destinationRepository.GetDestinationDetails(name);
                //Destination destinationDetails = await _destinationRepository.GetDestinationDetails(name);
                return _mapper.Map<DestinationDTO>(dest);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving destination details", ex);
            }
        }

             
  
    }
}
