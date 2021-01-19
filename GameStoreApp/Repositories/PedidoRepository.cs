using System;
using GameStoreApp.Context;
using GameStoreApp.Models;

namespace GameStoreApp.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;
        private CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext context,
                                CarrinhoCompra carrinhoCompra)
        {
            _context = context;
            _carrinhoCompra = carrinhoCompra;

        }
        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach(var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetalhe = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    JogoId = carrinhoItem.Jogo.JogoId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Jogo.Preco
                };
                _context.PedidoDetalhes.Add(pedidoDetalhe);
            }
            _context.SaveChanges();
        }
    }
}