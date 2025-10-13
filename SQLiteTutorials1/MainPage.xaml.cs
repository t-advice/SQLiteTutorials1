using SQLiteTutorials1.Models;


namespace SQLiteTutorials1
{
    public partial class MainPage : ContentPage
    {
        private Note selectedNote;
        

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
            if (string.IsNullOrWhiteSpace(text))
                return;

            if (selectedNote != null)
            {
                // Update existing note
                selectedNote.Text = text;
                await App.Database.SaveNoteAsync(selectedNote);
                selectedNote = null;
            }
            else
            {
                // Create new note
                var note = new Note
                {
                    Text = text,
                    CreatedAt = DateTime.Now
                };
                await App.Database.SaveNoteAsync(note);
            }

            NoteEntry.Text = string.Empty;
            await DisplayAlert("Saved", "Your note was saved successfully!", "OK");
            LoadNotes();
        }
        private async void OnDeleteNoteClicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var noteToDelete = menuItem?.CommandParameter as Note;
            if (noteToDelete != null)
            { 
                bool confirm = await DisplayAlert("Delete", $"Are you sure you want to delete this note?", "Yes", "No");
                if (confirm)
                {
                    await App.Database.DeleteNoteAsync(noteToDelete);
                    LoadNotes(); // Refresh the list
                }
            }
        }



    }
}
