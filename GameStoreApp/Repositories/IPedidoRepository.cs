using GameStoreApp.Models;

namespace GameStoreApp.Repositories
{
    public interface IPedidoRepository
    {
         void CriarPedido(Pedido pedido);
    }
}