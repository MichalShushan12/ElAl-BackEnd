using AutoMapper;
using ElAlAIR.BusinessLogic.Interfaces;
using ElAlAIR.BusinessLogic.Services;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElAlAIR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentsController : ControllerBase
    {
        private IContinentService _continentService;
        private IMapper _mapper;

        public ContinentsController(IContinentService continentService, IMapper mapper)
        {
            _continentService = continentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContinentDTO>>> GetAllContinents()
        {
            try
            {
                var contList = await _continentService.GetAllContinents();

                if (contList == null)
                {
                    return NotFound();
                }

                return Ok(contList);
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("mycontinent/{continentId}")]
        public async Task<ActionResult<ContinentDTO>> GetContinentById(Guid continentId)
        {
            try
            {
                var contId = await _continentService.GetContinentById(continentId);

                if (contId == null)
                {
                    return NotFound();
                }

                return Ok(contId);
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
