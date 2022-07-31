
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie07.Models;
using Zadanie07.Repositories.Interfaces;
namespace Zadanie07.Repositories.Implementations
{
    public class ClientDbReposiitory : IClientDbRepository
    {
        private readonly Context context;

        public ClientDbReposiitory(Context context)
        {
            this.context = context;
        }

        public async Task DeleteClientAsync(int idClient)
        {
            bool hasTrips = await context.ClientTrips.AnyAsync(row => row.IdClient == idClient);

            if (hasTrips) throw new Exception("Client has one or more trips!");

            Client client = await context.Clients.Where(row => row.IdClient == idClient).FirstOrDefaultAsync();
            context.Remove(client);

            await context.SaveChangesAsync();
        }
    }
}