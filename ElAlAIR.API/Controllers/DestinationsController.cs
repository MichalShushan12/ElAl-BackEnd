using AutoMapper;
using ElAlAIR.BusinessLogic.Interfaces;
using ElAlAIR.DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElAlAIR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private IDestinationService _destinationService;
        private IMapper _mapper;

        public DestinationsController(IDestinationService destinationService, IMapper mapper)
        {
            _destinationService = destinationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DestinationDTO>>> GetAllDestinations()
        {
            try
            {
                var destList = await _destinationService.GetAllDestinations();

                if (destList == null)
                {
                    return NotFound();
                }

                return Ok(destList);
            }

            catch (Exception)
            {
                throw;
            }
        }

        //[HttpGet("{destinationId}")]
        //public async Task<ActionResult<DestinationDTO>> GetDestinationById(Guid destinationId)
        //{
        //    try
        //    {
        //        var destId = await _destinationService.GetDestinationById(destinationId);
                
        //        if (destId == null)
        //        {
        //            return NotFound();     
        //        }

        //        return Ok(destId);
            
        //    }

        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpGet("{name}")]

        public async Task<ActionResult<DestinationDTO>> GetDestinationDetails(string name)
        {
            try
            {
                var dest = await _destinationService.GetDestinationDetails(name);
                
                if (dest == null)
                {
                    return NotFound();
                }

                return Ok(dest);
            }

            catch (Exception)
            {
                throw;
            }
        }



    }
}
