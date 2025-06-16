using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesTakingApp.Data
{
    public interface INotesRepository
    {
        void CreateNote(Note note);
        List<Note> GetAllNotes();
        Note? GetNoteById(int id);
        void DeleteNote(Note note);
    }
}
