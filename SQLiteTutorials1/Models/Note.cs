using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SQLiteTutorials1.Models // Namespace for the models in the SQLiteTutorials1 application
{
    public class Note // Note class representing a note entity in the database
    {
        [PrimaryKey, AutoIncrement]  // This attribute marks the property as the primary key and enables auto-increment
        public int Id { get; set; }  // Unique identifier for each note

        [MaxLength(250)] // This attribute sets a maximum length for the text
        public string Text { get; set; } // The content of the note
        //public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; } // Timestamp for when the note was created

        // This defines a simple table with three columns: Id, Text, and Date.

    }
}
