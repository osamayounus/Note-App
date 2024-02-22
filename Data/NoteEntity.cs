using Microsoft.EntityFrameworkCore;
using Note_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_App.Data
{
    public class NoteEntity : IDataHelper<Note>
    {
        private DBContext dbContext;
        public NoteEntity() { dbContext = new DBContext(); }
        public async Task AddDataAsync(Note table)
        {
            await dbContext.AddAsync(table);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Note> FindAsync(int Id)
        {
            return await dbContext.Notes.FindAsync(Id);
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await dbContext.Notes.ToListAsync();
        }

        public async Task RemoveDataAsync(Note table)
        {
            dbContext.Notes.Remove(table);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateDataAsync(Note table)
        {
            dbContext = new DBContext();
            dbContext.Notes.Update(table);
            await dbContext.SaveChangesAsync();
        }
    }
}
