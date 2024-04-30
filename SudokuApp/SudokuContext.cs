using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp
{
    public class SudokuContext : DbContext
    {
        public DbSet<SudokuGame> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Připojení k databázi SQL Server
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SudokuSolverDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
