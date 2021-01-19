using System.Collections.Generic;
using System.Linq;
using GameStoreApp.Context;
using GameStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApp.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly AppDbContext _context;

        public JogoRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Jogo> Jogos => _context.Jogos.Include(c => c.Categoria);

        public IEnumerable<Jogo> JogosPreferidos => _context.Jogos.Where(p => 
        p.isJogoPreferido).Include(c => c.Categoria);
        public Jogo GetJogoById(int jogoId)
        {
           return _context.Jogos.FirstOrDefault(j => j.JogoId == jogoId);
        }
    }
}