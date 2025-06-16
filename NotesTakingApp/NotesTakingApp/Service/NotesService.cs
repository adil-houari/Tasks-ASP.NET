using NotesTakingApp.Data;

namespace NotesTakingApp
{
    public class NotesService
    {
        private readonly INotesRepository repository;

        public NotesService(INotesRepository repository)
        {
            this.repository = repository;
        }


        public List<Note> GetNotes(int offset = 0, int limit = 5)
        {
            return repository.GetAllNotes().Skip(offset).Take(limit).ToList();
        }

        public List<Note> SearchNotes(string value)
        {
            return repository.GetAllNotes().Where(note => note.Content.Contains(value) || note.Title.Contains(value)).ToList();
        }

        public void CreateNote(string title, string content)
        {
            Note note = new Note() { Title = title, Content = content };
            repository.CreateNote(note);
        }

        public bool DeleteNote(int id)
        {
            Note? note = repository.GetNoteById(id);

            if (note != null)
            {
                repository.DeleteNote(note);
                return true;
            } else
            {
                return false;
            }
            
        }
    }
}
