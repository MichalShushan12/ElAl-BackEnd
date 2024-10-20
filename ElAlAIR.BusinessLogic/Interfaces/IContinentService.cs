using ElAlAIR.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.BusinessLogic.Interfaces
{
    public interface IContinentService
    {
        public Task<List<ContinentDTO>> GetAllContinents();


        public Task<ContinentDTO> GetContinentById(Guid continentId);
    }
}
