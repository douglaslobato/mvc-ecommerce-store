using System.Collections.Generic;
using GameStoreApp.Models;

namespace GameStoreApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Jogo> JogosPreferidos { get; set; }
    }
}