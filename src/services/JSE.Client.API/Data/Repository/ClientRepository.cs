
using JSE.Client.API.Models;
using JSE.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace JSE.Client.API.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientContext _context;

        public ClientRepository(ClientContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Clients>> GetAll()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();
        }

        public Task<Clients> GetByDocument(string documentNumber)
        {
            return _context.Clients.FirstOrDefaultAsync(c => c.DocumentNumber.DocumentNumber == documentNumber);
        }

        public void Add(Clients client)
        {
            _context.Clients.Add(client);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
