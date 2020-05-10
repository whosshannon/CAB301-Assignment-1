using NUnit.Framework;
using System;

namespace Library_Program_Test
{
    [TestFixture()]
    public class MovieTest
    {
        string name = "Harry Potter and the Philosopher's Stone";
        string[] cast = { "Daniel Radcliffe", "Emma Watson", "Rupert Grint" };
        string director = "Chris Columbus";
        int runtime = 159;
        Library_Program.Movie.GenreType genre = Library_Program.Movie.GenreType.Adventuer;
        Library_Program.Movie.ClassificationType classification = Library_Program.Movie.ClassificationType.ParentalGuidance;
        int copies = 6;
        Library_Program.Movie harryPotter;

        [Test()]
        public void MovieObjectConstruction()
        {
            harryPotter = new Library_Program.Movie(name, cast, director, runtime, genre, classification, copies);
            Assert.That(harryPotter.getTitle() == "Harry Potter and the Philosopher's Stone");
        }
    }
}
