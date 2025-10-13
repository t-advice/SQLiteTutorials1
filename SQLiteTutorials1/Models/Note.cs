using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SQLiteTutorials1.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Text { get; set; }
        //public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; }

        // This defines a simple table with three columns: Id, Text, and Date.

    }
}
