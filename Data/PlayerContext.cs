using APIApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApplication.Data
{
    public class PlayerContext: DbContext
    {

        public PlayerContext(DbContextOptions<PlayerContext> opt) : base(opt)
        {

        }

        public DbSet<Players> Players { get; set; }

    }

}
