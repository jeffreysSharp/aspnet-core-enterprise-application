﻿using JSE.Core.Data;

namespace JSE.Catalogo.API.Models
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
        Task<List<Produto>> ObterProdutosPorId(string ids);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
    }
}
