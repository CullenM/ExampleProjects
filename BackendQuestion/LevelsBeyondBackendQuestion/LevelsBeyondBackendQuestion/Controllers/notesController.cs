using System.Collections.Generic;
using System.Web.Http;
using LevelsBeyondBackendQuestion.Models;
using LevelsBeyondBackendQuestion.Data;

namespace LevelsBeyondBackendQuestion.Controllers
{
    public class notesController : ApiController
    {

        // GET: api/notes/(int)
        public Note Get(int id)
        {            
            Note note = NoteTable.GetNoteById(id);
            return note;
        }

        // GET: api/notes
        public List<Note> Get(string query=null)
        {
            List<Note> notes = null;
            if (query == null)
            {
                notes = NoteTable.GetNotes();
            }
            else
            {
                notes = NoteTable.GetNoteByBody(query);
            }
            return notes;
        }

        // POST: api/notes
        public Note Post([FromBody]Note note)
        {
            return NoteTable.InsertNote(note.Body);
        }
    }
}