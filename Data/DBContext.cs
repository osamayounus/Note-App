using Microsoft.EntityFrameworkCore;
using Note_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_App.Data
{
    public class DBContext:DbContext
    {
        // Add tabels
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filename = Path.Combine(path, "AppDBNote.db");
            optionsBuilder.UseSqlite($"FileName={filename}");
        }
    }
}
