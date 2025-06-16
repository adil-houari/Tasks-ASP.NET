using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NotesTakingApp.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesTakingApp.Tests.Data
{
    public class NotesRepositoryTests
    {
        // AAA METHODE (zie powerpoint) // Arrange // Act // Assert
        // sut gebruiken als naam
        // naamgeveving (zie les 5 powerpoint)
        // Constructor niet globaal maken, in de test zelf creeren
        // global using FluentAssertions; && global using NSubstitute; toevoegen in GlobalUsing
        // zie demo les 5 + les 4 (update) voor Substitute

        [Fact]
        public void CreateNote_WithNote_AddNoteToDatabase()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new Note { Title = "broooo ", Content = "this is a mercedes AMG GT63S" };
            repository.CreateNote(sut);
            repository.When(content => content.CreateNote(sut)).Do(callInfo => sut.Id = 1);

            // Act
            repository.CreateNote(sut);

            // Assert
            Assert.Equal(1, sut.Id);
        }

        [Fact]
        public void GetAllNotes_WithNotesInDB_ReturnsAllItems()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new List<Note>
            {
                new Note { Id = 1, Title = "Car1", Content = "Lamborghini urus s" },
                new Note { Id = 2, Title = "Car2", Content = "Ferrari SF90" },
            };
            repository.GetAllNotes().Returns(sut);

            // Act
            var notes = repository.GetAllNotes();

            // Assert
            Assert.Equal(sut, notes);
        }

        [Fact]
        public void GetAllNotes_WithoutNotesInDB_ReturnsEmptyList()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new List<Note>();
            repository.GetAllNotes().Returns(sut);

            // Act
            var notes = repository.GetAllNotes();

            // Assert
            Assert.Empty(notes);
        }

        [Fact]
        public void GetNoteById_WithExistingNoteId_ReturnsNote()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new Note { Id = 1, Title = "Car", Content = "BMW M5CS" };
            repository.GetNoteById(1).Returns(sut);

            // Act
            var savedNote = repository.GetNoteById(1);

            // Assert
            Assert.Equal(sut, savedNote);

        }

        [Fact]
        public void GetNoteById_WithNonExistingId_ReturnsNull()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            repository.GetNoteById(1).Returns((Note)null);

            // Act
            var savedNote = repository.GetNoteById(1);

            // Assert
            Assert.Null(savedNote);
        }

        [Fact]
        public void DeleteNote_WithExistingNote_RemovesNote()
        {
            // Arrange
            INotesRepository repository = Substitute.For<INotesRepository>();
            var sut = new Note { Id = 1, Title = "Car", Content = "Rolls Royce Cullinan" };
            repository.GetNoteById(1).Returns(sut);

            // Act
            repository.DeleteNote(sut);

            // Assert
            repository.Received(1).DeleteNote(sut);
        }
    }
}
