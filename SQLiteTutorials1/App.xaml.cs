using SQLiteTutorials1.Service;


namespace SQLiteTutorials1
{
    public partial class App : Application
    {
        private static DatabaseService _database;
        public static DatabaseService Database
        {
            get
            {
                if (_database == null)
                { 
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3");
                    _database = new DatabaseService(dbPath);
                }
                return _database;
            }
        
        
        }


        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        
    }
}