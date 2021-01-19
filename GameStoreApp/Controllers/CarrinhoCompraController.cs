using System.Linq;
using GameStoreApp.Models;
using GameStoreApp.Repositories;
using GameStoreApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreApp.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IJogoRepository jogoRepository,
                                        CarrinhoCompra carrinhoCompra)
        {
            _jogoRepository = jogoRepository;
            _carrinhoCompra = carrinhoCompra;
        }
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        [Authorize(Roles = "Admin, Member")]
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int jogoId)
        {
            var jogoSelecionado = _jogoRepository.Jogos.FirstOrDefault(p => p.JogoId == jogoId);

            if (jogoSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(jogoSelecionado, 1);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Member")]
        public IActionResult RemoverItemDoCarrinhoCompra(int jogoId)
        {
            var jogoSelecionado = _jogoRepository.Jogos.FirstOrDefault(p => p.JogoId == jogoId);
            if (jogoSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(jogoSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}