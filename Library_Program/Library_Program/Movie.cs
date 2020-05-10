using System;
namespace Library_Program
{
    public class Movie
    {
        public enum GenreType
        {
            Drama,
            Adventuer,
            Family,
            Action,
            SciFi,
            Comedy,
            Aimated,
            Thriller,
            Other
        }

        public enum ClassificationType
        {
            General,
            ParentalGuidance,
            Mature,
            MatureAccompanied
        }

        string title;
        string[] starring;
        string director;
        int duration;
        GenreType genre;
        ClassificationType classification;
        int copies;
        int currentlyRented;
        int copiesAvailable;
        int timesRented;

        /// <summary>
        /// Creates an object Movie
        /// </summary>
        /// <param name="titleName">String of the title of the movie</param>
        /// <param name="cast">String array of the casts names</param>
        /// <param name="directorName">String of the directors name</param>
        /// <param name="runTime">Integer of the runtime of the movie in minutes</param>
        /// <param name="givenGenre">Enum of GenreType</param>
        /// <param name="givenClassification">Enum of ClassificationType</param>
        /// <param name="numberOfCopies">Int of the number of copies the library owns</param>
        public Movie(string titleName, string[] cast, string directorName, int runTime, GenreType givenGenre, ClassificationType givenClassification, int numberOfCopies) 
        {
            title = titleName;
            starring = cast;
            director = directorName;
            duration = runTime;
            genre = givenGenre;
            classification = givenClassification;
            copies = numberOfCopies;
            currentlyRented = 0;
            copiesAvailable = copies - currentlyRented;
            timesRented = 0;
        }

        public string getTitle()
        {
            return title;
        }

        public string getStarring()
        {
            return string.Join(", ", starring);
        }

        public string displayMovie()
        {
            string movieInfo = "Title: " + title + "\n\t Starring: " + getStarring() +
                "\n\t Director: " + director + ",\n\t Runtime: " + duration +
                "minutes \n\t Genre: " + genre + "\n\t Classification: " + classification +
                "\n\t Copies available: " + copiesAvailable;
            return movieInfo;
        }
    }
}
