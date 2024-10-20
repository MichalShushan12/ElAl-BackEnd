using ElAlAIR.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DataAccess.Interfaces
{
    public interface IDestinationRepository
    {
        public Task<List<Destination>> GetAllDestinations();

        //public Task<Destination> GetDestinationById(Guid destinationId);

        public Task<Destination> GetDestinationDetails(string name);
    }
}
