using System.Collections.Generic;
using GameStoreApp.Models;

namespace GameStoreApp.ViewModels
{
    public class JogoListViewModel
    {
        public IEnumerable<Jogo> Jogos { get; set; }
        public string CategoriaAtual { get; set; }
    }
}