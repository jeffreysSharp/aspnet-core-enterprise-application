namespace JSE.Bff.Compras.Models
{
    public class PedidoDTO
    {
        #region Pedido

        public int Codigo { get; set; }
        // Autorizado = 1,
        // Pago = 2,
        // Recusado = 3,
        // Entregue = 4,
        // Cancelado = 5
        public int Status { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }

        public decimal Desconto { get; set; }
        public string VoucherCodigo { get; set; }
        public bool VoucherUtilizado { get; set; }

        public List<ItemCarrinhoDTO> PedidoItems { get; set; }

        #endregion

        #region Endereco

        public EnderecoDTO Endereco { get; set; }

        #endregion
    }
}