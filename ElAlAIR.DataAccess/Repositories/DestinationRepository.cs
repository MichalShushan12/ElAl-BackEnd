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
    public class DestinationRepository : IDestinationRepository
    {
        private ElalDbContext _elalContext;

        public DestinationRepository(ElalDbContext elalContext)
        {
            _elalContext = elalContext;
        }

        public async Task<List<Destination>> GetAllDestinations()
        {
            try
            {
                return await _elalContext.Destinations.ToListAsync();

               // return _elalContext.Destinations.ToList();
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        //public async Task<Destination> GetDestinationById(Guid destinationId)
        //{
        //    try
        //    {

        //        return _elalContext.Destinations.FirstOrDefault(d => d.DestinationId == destinationId);

        //    }

        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Error creating order", ex);
        //    }
        //}

        public async Task<Destination> GetDestinationDetails(string name)
        {
            try
            {
                return await _elalContext.Destinations.FirstOrDefaultAsync(p => p.Name == name);

                //return _elalContext.Destinations.FirstOrDefault(p => p.Name == name);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }
    }
}
