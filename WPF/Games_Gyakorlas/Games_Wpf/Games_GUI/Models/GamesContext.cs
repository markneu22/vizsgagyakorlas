using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games_GUI.Models
{
    public class GamesContext : DbContext
    {
        public DbSet<GameModel> Game { get; set; }
        public DbSet<PublisherModel> Publisher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string constring = "Server=localhost;Database=games_14A;Uid=root;Pwd=;";

            optionsBuilder.UseMySql(constring, ServerVersion.AutoDetect(constring));
        }
    }
}
