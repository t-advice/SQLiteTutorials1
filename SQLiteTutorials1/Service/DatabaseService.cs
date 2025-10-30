using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteTutorials1.Models;
using SQLite;

namespace SQLiteTutorials1.Service // Namespace for the service layer of the SQLiteTutorials1 application
{
    public class DatabaseService // Database service class for managing SQLite database operations
    {
        private readonly SQLiteAsyncConnection _database; // SQLite connection object
        public DatabaseService(string dbPath) // Constructor that takes the database path as a parameter
        {
            _database = new SQLiteAsyncConnection(dbPath); 
            _database.CreateTableAsync<Note>().Wait();
        }
        public Task<List<Note>> GetNotesAsync() // Method to retrieve all notes from the database
        {
            return _database.Table<Note>().ToListAsync(); 
        }

        public Task<int> SaveNoteAsync(Note note) // Method to save a note (insert or update)
        {
            if (note.Id != 0)
                return _database.UpdateAsync(note); 
            else 
                return _database.InsertAsync(note); 
        }
        public Task<int> DeleteNoteAsync(Note Note) // Method to delete a note from the database
        {
            return _database.DeleteAsync(Note); 

        }


    }
}
