using JSE.Core.Data;
using JSE.Core.Mediator;
using Microsoft.EntityFrameworkCore;

namespace JSE.Pedidos.Infra.Data
{
    public class PedidosContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public PedidosContext(DbContextOptions<PedidosContext> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public Task<bool> Commit()
        {
            throw new NotImplementedException();
        }
    } 
}