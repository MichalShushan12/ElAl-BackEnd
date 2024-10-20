using ElAlAIR.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.BusinessLogic.Interfaces
{
    public interface IDestinationService
    {
        public Task<List<DestinationDTO>> GetAllDestinations();
        //public Task<DestinationDTO> GetDestinationById(Guid destinationId);

        public Task<DestinationDTO> GetDestinationDetails(string name);
    }
}
