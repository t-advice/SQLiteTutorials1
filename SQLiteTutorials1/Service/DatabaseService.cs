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
            _database = new SQLiteAsyncConnection(dbPath); // Initialize the SQLite connection
            _database.CreateTableAsync<Note>().Wait(); // Create the Note table if it doesn't exist
        }
        public Task<List<Note>> GetNotesAsync() // Method to retrieve all notes from the database
        {
            return _database.Table<Note>().ToListAsync(); // Return all notes as a list
        }

        public Task<int> SaveNoteAsync(Note note) // Method to save a note (insert or update)
        {
            if (note.Id != 0) // If the note has an Id, it already exists in the database
                return _database.UpdateAsync(note); // Update the existing note
            else // If the note doesn't have an Id, it's a new note
                return _database.InsertAsync(note); // Insert the new note
        }
        public Task<int> DeleteNoteAsync(Note Note) // Method to delete a note from the database
        {
            return _database.DeleteAsync(Note); // Delete the specified note
        }


    }
}
