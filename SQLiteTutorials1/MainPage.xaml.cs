using SQLiteTutorials1.Models;


namespace SQLiteTutorials1
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            LoadNotes();
        }

        private async void LoadNotes()
        {
            NotesList.ItemsSource = await App.Database.GetNotesAsync();
        }
        private async void OnSaveNoteClicked(object sender, EventArgs e)
        {
            var text = NoteEntry.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                var note = new Note
                {
                    Text = text,
                    CreatedAt = DateTime.Now
                };
                await App.Database.SaveNoteAsync(note);
                NoteEntry.Text = string.Empty;
                LoadNotes();
            }
        
        }


        
    }
}
