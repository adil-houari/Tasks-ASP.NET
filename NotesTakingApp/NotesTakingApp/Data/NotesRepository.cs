using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesTakingApp.Data
{
    public class NotesRepository : INotesRepository
    {

        public void CreateNote(Note note)
        {
            using(var context = new AppDbContext())
            {
                context.Notes.Add(note);
                context.SaveChanges();
            }
        }

        public List<Note> GetAllNotes()
        {
            using(var context = new AppDbContext())
            {
                return context.Notes.ToList();
            }
        }

        public Note? GetNoteById(int id)
        {
            using(var context = new AppDbContext())
            {
                return context.Notes.Find(id);
            }
        }

        public void DeleteNote(Note note)
        {
            using (var context = new AppDbContext() )
            {
                context.Remove(note);
                context.SaveChanges();
            }
        }
    }
}
