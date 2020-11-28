using APIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApplication.Data
{
   public interface IPlayerRepo
    {
        bool SaveChanges();

        IEnumerable<Players> GetAllPlayers();
        Players GetPlayerById(int id);
        void CreatePlayer(Players player);
        void UpdatePlayer(Players player);
        void DeletePlayer(Players player);
    }
}
