using System.Collections.Generic;
using GameStoreApp.Models;

namespace GameStoreApp.ViewModels
{
    public class PedidoJogoViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}