using APIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApplication.Data
{

    public class SqlPlayerRepo : IPlayerRepo
    {
        private readonly PlayerContext _context;
        public SqlPlayerRepo(PlayerContext context)
        {
            _context = context;
        }
        public void CreatePlayer(Players player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            _context.Players.Add(player); ;
        }

        public void DeletePlayer(Players player)
        {
            if (player == null)
            {
                throw new NotImplementedException();
            }

            _context.Players.Remove(player);
        }

        public IEnumerable<Players> GetAllPlayers()
        {
            return _context.Players.ToList();
        }

        public Players GetPlayerById(int id)
        {
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePlayer(Players player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            _context.Players.Update(player); ;
        }
    }
}
