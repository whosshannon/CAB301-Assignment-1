using System;
namespace Library_Program
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string mainMenu = "Welcome to the Community Library!" +
                "\n===========Main Menu============" +
                "\n 1.\t Staff login" +
                "\n 2.\t Member login" +
                "\n 0.\t Exit" +
                "\n================================" +
                "\n\nPlease make aselection (1-2, or 0 to exit)\n";
            string staffMenu = "===========Staff Menu===========" +
                "\n 1.\t Add a new movie" +
                "\n 2.\t Remove a movie" +
                "\n 3.\t Register a new Member" +
                "\n 4.\t Find a registered member's phone number" +
                "\n 0.\t Return to main menu" +
                "\n================================" +
                "\n\nPlease make a selection (1-4, or 0 to return to main menu)\n";
            string memberMenu = "===========Member Menu==========" +
                "\n 1.\t Display all movies" +
                "\n 2.\t Borrow a movie" +
                "\n 3.\t Return a movie" +
                "\n 4.\t List current borrowed movies" +
                "\n 5.\t Display top 10 most popular movies" +
                "\n 0.\t Return to main menu" +
                "\n================================" +
                "\n\nPlease make a selection (1-5, or 0 to return to main menu)\n";

            Console.WriteLine(mainMenu);
            Console.WriteLine(staffMenu);
            Console.WriteLine(memberMenu);


            string name = "Harry Potter and the Philosopher's Stone";
            string[] cast = { "Daniel Radcliffe", "Emma Watson", "Rupert Grint" };
            string director = "Chris Columbus";
            int runtime = 159;
            Movie.GenreType genre = Movie.GenreType.Adventuer;
            Movie.ClassificationType classification = Movie.ClassificationType.ParentalGuidance;
            int copies = 6;
            Movie harryPotter = new Movie(name, cast, director, runtime, genre, classification, copies);

            Console.WriteLine(harryPotter.displayMovie());
        }
    }
}
