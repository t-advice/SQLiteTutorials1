using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteTutorials1.Models;
using SQLite;

namespace SQLiteTutorials1.Service
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;
        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();
        }
        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
                return _database.UpdateAsync(note);
            else
                return _database.InsertAsync(note);
        }
        public Task<int> DeleteNoteAsync(Note Note)
        {
            return _database.DeleteAsync(Note);
        }


    }
}
