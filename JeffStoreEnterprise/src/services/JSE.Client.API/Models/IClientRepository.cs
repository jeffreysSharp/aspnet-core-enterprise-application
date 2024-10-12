using JSE.Core.Data;

namespace JSE.Client.API.Models
{
    public interface IClientRepository : IRepository<Clients>
    {
        void Add(Clients client);
        Task<IEnumerable<Clients>> GetAll();
        Task<Clients> GetByDocument(string documentNumber);
    }
}
