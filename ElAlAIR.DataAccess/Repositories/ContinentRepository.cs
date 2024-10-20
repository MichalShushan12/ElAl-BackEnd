using ElAlAIR.DataAccess.DataContext;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DataAccess.Repositories
{
    public class ContinentRepository : IContinentRepository
    {
        private ElalDbContext _elalContext;

        public ContinentRepository(ElalDbContext elalContext)
        {
            _elalContext = elalContext;
        }

        public async Task<List<Continent>> GetAllContinents()
        {
            try
            {
                return await _elalContext.Continents.ToListAsync();
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        public async Task<Continent> GetContinentById(Guid continentId)
        {
            try
            {
                return _elalContext.Continents.FirstOrDefault(c => c.ContinentId == continentId);

                // return _elalContext.Continents.FirstOrDefault(c => c.ContinentId == continentId);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }
    }
}
