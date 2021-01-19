using System.Collections.Generic;
using GameStoreApp.Context;
using GameStoreApp.Models;

namespace GameStoreApp.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}