
using System.Collections.Generic;
using System.Threading.Tasks;
using Zadanie07.Models.DTO.Request;
using Zadanie07.Models.DTO.Response;

namespace Zadanie07.Repositories.Interfaces
{
    public interface ITripDbRepository
    {
        Task<IEnumerable<GetTripsResponseDto>> GetTripsAsync();
        Task AddTripToClientAsync(int idTrip, AddTripToClientRequestDto dto);
    }
}