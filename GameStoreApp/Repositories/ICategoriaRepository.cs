using System.Collections.Generic;
using GameStoreApp.Models;

namespace GameStoreApp.Repositories
{
    public interface ICategoriaRepository
    {
         IEnumerable<Categoria> Categorias {get;}
    }
}