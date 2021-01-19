using System.Collections.Generic;
using System.Linq;
using GameStoreApp.Models;
using GameStoreApp.Repositories;
using GameStoreApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreApp.Controllers
{
    public class JogoController : Controller
    {
        private readonly IJogoRepository _jogoRepository;
        private ICategoriaRepository _categoriaRepository;

        public JogoController(IJogoRepository jogoRepository, ICategoriaRepository categoriaRepository)
        {
            _jogoRepository = jogoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable<Jogo> jogos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                jogos = _jogoRepository.Jogos.OrderBy(p => p.JogoId);
                categoriaAtual = "Todos os Jogos";
            }
            else
            {

                jogos = _jogoRepository.Jogos
                           .Where(p => p.Categoria.CategoriaNome.Equals(categoria))
                           .OrderBy(p => p.Nome);

                categoriaAtual = categoria;
            }

            var jogoListViewModel = new JogoListViewModel
            {
                Jogos = jogos,
                CategoriaAtual = categoriaAtual
            };

            return View(jogoListViewModel);

        }

        public IActionResult Details(int jogoId)
        {
            var jogo = _jogoRepository.Jogos.FirstOrDefault(j => j.JogoId == jogoId);
            if(jogo ==null)
            {
                return BadRequest("Not Found");
            }

            return View(jogo);
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Jogo> jogos;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                jogos = _jogoRepository.Jogos.OrderBy(p => p.JogoId);
            }
            else
            {
                jogos = _jogoRepository.Jogos.Where(p => p.Nome.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Jogo/List.cshtml", new JogoListViewModel { Jogos = jogos, CategoriaAtual = "Todos os jogos"});
        }
    }
}