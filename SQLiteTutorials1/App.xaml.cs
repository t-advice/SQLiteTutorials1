using SQLiteTutorials1.Service;


namespace SQLiteTutorials1
{
    public partial class App : Application
    {
        private static DatabaseService _database; // Private static variable to hold the singleton instance of DatabaseService
        public static DatabaseService Database //Static property to access the DatabaseService instance
        {
            get // Public static property to access the DatabaseService instance
            {
                if (_database == null) // If the database instance is not created yet
                { 
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"); // Define the path for the SQLite database file
                    _database = new DatabaseService(dbPath); // Create a new instance of DatabaseService with the specified database path
                }
                return _database; // Return the singleton instance of DatabaseService
            }
        
        
        }


        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); // Set the main page of the application to AppShell
        }

        
    }
}