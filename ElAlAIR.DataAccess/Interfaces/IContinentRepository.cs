using ElAlAIR.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DataAccess.Interfaces
{
    public interface IContinentRepository
    {
        public Task<List<Continent>> GetAllContinents();

        public Task<Continent> GetContinentById(Guid continentId);
    }
}
