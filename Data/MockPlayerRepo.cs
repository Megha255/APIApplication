using APIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApplication.Data
{
    public class MockPlayerRepo : IPlayerRepo
    {
        public void CreatePlayer(Players player)
        {
            throw new NotImplementedException();
        }

        public void DeletePlayer(Players player)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Players> GetAllPlayers()
        {

            var players = new List<Players>
            {
                new Players{Id=1, Name="Ben", Age=29, Nationality="English", Status="All-rounder"},
                new Players{Id=2, Name="Pollard", Age=33, Nationality="West Indian", Status="All-rounder"},
               new Players{Id=3,  Name="Kohli", Age=32, Nationality="Indian", Status="Batsman"}
            };

            return players;
        }

        public Players GetPlayerById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayer(Players player)
        {
            throw new NotImplementedException();
        }
    }
}
