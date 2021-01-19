using System.Collections.Generic;
using GameStoreApp.Models;

namespace GameStoreApp.Repositories
{
    public interface IJogoRepository
    {
         IEnumerable<Jogo> Jogos {get;}
         IEnumerable<Jogo> JogosPreferidos {get;}
         Jogo GetJogoById(int jogoId);
    }
}