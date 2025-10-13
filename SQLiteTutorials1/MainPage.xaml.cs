using SQLiteTutorials1.Models;


namespace SQLiteTutorials1
{
    public partial class MainPage : ContentPage
    {
        private Note selectedNote; // To keep track of the selected note for editing


        public MainPage()
        {
            InitializeComponent();
            LoadNotes(); // Load notes when the page is initialized
        }

        private async void LoadNotes() // Method to load notes from the database
        {
            NotesList.ItemsSource = await App.Database.GetNotesAsync(); // Fetch notes from the database and set as the item source for the ListView
        }
        private async void OnSaveNoteClicked(object sender, EventArgs e)
        {
            var text = NoteEntry.Text; // Get the text from the Entry field
            if (string.IsNullOrWhiteSpace(text)) // Validate input
                return; // Do nothing if the text is empty or whitespace

            if (selectedNote != null) // If a note is selected, we are editing an existing note
            {
                // Update existing note
                selectedNote.Text = text; // Update the text of the selected note
                await App.Database.SaveNoteAsync(selectedNote); // Save the updated note to the database
                selectedNote = null; // Clear the selected note after updating
            }
            else // Create new note
            {
                // Create new note
                var note = new Note // Create a new Note object
                {
                    Text = text, // Set the note text
                    CreatedAt = DateTime.Now // Set the creation date to the current date and time
                };
                await App.Database.SaveNoteAsync(note); // Save the new note to the database
            }

            NoteEntry.Text = string.Empty; // Clear the Entry field
            await DisplayAlert("Saved", "Your note was saved successfully!", "OK");// Show confirmation
            LoadNotes(); // Refresh the list
        }
        private async void OnDeleteNoteClicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem; // Get the MenuItem that was clicked
            var noteToDelete = menuItem?.CommandParameter as Note; // Get the Note associated with the MenuItem
            if (noteToDelete != null)// If there is a note to delete
            { 
                bool confirm = await DisplayAlert("Delete", $"Are you sure you want to delete this note?", "Yes", "No");
                if (confirm) // If the user confirms deletion
                {
                    await App.Database.DeleteNoteAsync(noteToDelete); // Delete the note from the database
                    LoadNotes(); // Refresh the list
                }
            }
        }
        private void OnNoteTapped(object sender, ItemTappedEventArgs e)
        {
            selectedNote = e.Item as Note; // Get the tapped note
            if (selectedNote != null) // If a note is selected
            {
                NoteEntry.Text = selectedNote.Text; // Populate the Entry field with the note's text for editing
            }
        }




    }
}
