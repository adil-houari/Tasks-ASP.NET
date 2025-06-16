using NotesTakingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesTakingApp.Tests.Service
{
    // AAA METHODE (zie powerpoint) // Arrange // Act // Assert
    // sut gebruiken als naam
    // naamgeveving (zie les 5 powerpoint)
    // Constructor niet globaal maken, in de test zelf creeren
    // global using FluentAssertions; && global using NSubstitute; toevoegen in GlobalUsing
    // zie demo les 5 + les 4 (update) voor Substitute

    public class NotesServiceTests
    {
        [Fact]
        public void GetNotes_WithDefaultValues_ReturnsFirst5Items()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new NotesService(repository);

            var notes = new List<Note>
            {
                new Note { Title = "Note 1", Content = "mercedes" },
                new Note { Title = "Note 2", Content = "bmw" },
                new Note { Title = "Note 3", Content = "Bentley" },
                new Note { Title = "Note 4", Content = "Rolls Royce" },
                new Note { Title = "Note 5", Content = "Aston Martin" },
                new Note { Title = "Note 6", Content = "Mclaren" },
                new Note { Title = "Note 7", Content = "Porsche" },
                new Note { Title = "Note 8", Content = "Audi" },
                new Note { Title = "Note 9", Content = "Bugatti" },
            };

            repository.GetAllNotes().Returns(notes);

            // Act
            var result = sut.GetNotes();

            // Assert
            var expectedNotes = notes.Take(5).ToList();
            Assert.Equal(expectedNotes, result);
        }

        [Fact]
        public void GetNotes_WithOffset2AndLimit2_ReturnsItem3And4()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new NotesService(repository);

            var notes = new List<Note>
            {
                new Note { Title = "Note 1", Content = "mercedes" },
                new Note { Title = "Note 2", Content = "bmw" },
                new Note { Title = "Note 3", Content = "Bentley" },
                new Note { Title = "Note 4", Content = "Rolls Royce" },
                new Note { Title = "Note 5", Content = "Aston Martin" },
                new Note { Title = "Note 6", Content = "Mclaren" },
                new Note { Title = "Note 7", Content = "Porsche" },
                new Note { Title = "Note 8", Content = "Audi" },
                new Note { Title = "Note 9", Content = "Bugatti" },
            };

            repository.GetAllNotes().Returns(notes);

            // Act
            var result = sut.GetNotes(offset: 2, limit: 2);

            // Assert
            var expectedNotes = notes.Skip(2).Take(2).ToList();
            Assert.Equal(expectedNotes, result);
        }

        [Fact]
        public void SearchNote_WithNoNotesInDb_ReturnsEmptyList()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new NotesService(repository);

            repository.GetAllNotes().Returns(new List<Note>());

            // Act
            var result = sut.SearchNotes("test");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SearchNote_WithNotesInDBAndSearchQueryThatDoenstMatch_ReturnsEmptyList()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new NotesService(repository);

            var notes = new List<Note>
            {
                new Note { Title = "Note 5", Content = "Aston Martin" },
                new Note { Title = "Note 6", Content = "Mclaren" },
                new Note { Title = "Note 7", Content = "Porsche" },
            };

            repository.GetAllNotes().Returns(notes);

            // Act
            var result = sut.SearchNotes("test");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SearchNote_WithNotesInDBAndSearchQueryThatMatch_ReturnsCorrectList()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new NotesService(repository);

            var notes = new List<Note>
            {
                new Note { Title = "Note 5", Content = "Aston Martin" },
                new Note { Title = "Note 6", Content = "Mclaren" },
                new Note { Title = "Note 7", Content = "Porsche" },
            };

            repository.GetAllNotes().Returns(notes);

            // Act
            var result = sut.SearchNotes("Note 6");

            // Assert
            var expectedNotes = notes.Where(note => note.Title.Contains("Note 6") || note.Content.Contains("Mclaren")).ToList();
            Assert.Equal(expectedNotes, result);
        }


        [Fact]
        public void CreateNote_WithTitleAndString_CallsCreateNoteWithCorrectNoteObject()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new NotesService(repository);

            // Act
            sut.CreateNote("Car", "Mclaren");

            // Assert
            repository.Received(1).CreateNote(Arg.Is<Note>(note => note.Title == "Car" && note.Content == "Mclaren"));
        }

        [Fact]
        public void DeleteNote_WithNonExistingID_ReturnsFalseAndDontCallDeleteNote()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new NotesService(repository);

            repository.GetNoteById(1).Returns((Note)null);

            // Act
            var result = sut.DeleteNote(1);

            // Assert
            Assert.False(result);
            repository.DidNotReceive().DeleteNote(Arg.Any<Note>());
        }


        [Fact]
        public void DeleteNote_WithExistingID_ReturnsTrueAndCallsDeleteNoteWithCorrectObject()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new NotesService(repository);
            var currenNote = new Note { Id = 1, Title = "car", Content = "Mercedes maybach 680 Mansory" };
            repository.GetNoteById(1).Returns(currenNote);

            // Act
            var result = sut.DeleteNote(1);

            // Assert
            Assert.True(result);
            repository.Received(1).DeleteNote(Arg.Is<Note>(note => note.Id == 1));
        }
    }
}
