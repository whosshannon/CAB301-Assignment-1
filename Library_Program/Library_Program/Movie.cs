using System;
namespace Library_Program
{
    public class Movie
    {
        public enum GenreType
        {
            Drama = 0,
            Adventure = 1,
            Family = 2,
            Action = 3,
            SciFi = 4,
            Comedy = 5,
            Animated = 6,
            Thriller = 7,
            Other = 8
        }

        public enum ClassificationType
        {
            General,
            ParentalGuidance,
            Mature,
            MatureAccompanied
        }

        string title;
        string starring;
        string director;
        int duration;
        GenreType genre;
        ClassificationType classification;
        DateTime releaseDate;
        int copies;
        int copiesAvailable;
        int timesRented;

        /// <summary>
        /// Creates an object Movie
        /// </summary>
        /// <param name="titleName">String of the title of the movie</param>
        /// <param name="cast">String of the lead actor/actress' name</param>
        /// <param name="directorName">String of the directors name</param>
        /// <param name="runTime">Integer of the runtime of the movie in minutes</param>
        /// <param name="givenGenre">Enum of GenreType</param>
        /// <param name="givenClassification">Enum of ClassificationType</param>
        /// <param name="date">Release date of the movie of DateTime type</param>
        /// <param name="numberOfCopies">Int of the number of copies the library owns</param>
        public Movie(string titleName, string cast, string directorName, int runTime, GenreType givenGenre, ClassificationType givenClassification, DateTime date, int numberOfCopies) 
        {
            title = titleName;
            starring = cast;
            director = directorName;
            duration = runTime;
            genre = givenGenre;
            classification = givenClassification;
            releaseDate = date;
            copies = numberOfCopies;
            copiesAvailable = copies;
            timesRented = 0;
        }

        public string GetTitle()
        {
            return title;
        }

        //public string GetStarring()
        //{
        //    return string.Join(", ", starring);
        //}

        //public string DisplayMovie()
        //{
        //    string movieInfo = "Title: " + title + "\n\t Starring: " + GetStarring() +
        //        "\n\t Director: " + director + ",\n\t Runtime: " + duration +
        //        " minutes \n\t Genre: " + genre + "\n\t Classification: " + classification +
        //        "\n\t Times rented: " + timesRented + "\n\t Copies available: " + copiesAvailable;
        //    return movieInfo;
        //}

        public string DisplayMovie()
        {
            string movieInfo = title.PadRight(50, ' ') + "| "
                + starring.PadRight(20, ' ') + "| "
                + director.PadRight(20, ' ') + "| "
                + duration.ToString().PadRight(10, ' ') + "| "
                + genre.ToString().PadRight(10, ' ') + "| "
                + classification.ToString().PadRight(18, ' ') + "| "
                + releaseDate.Date.ToString("d").PadRight(12, ' ') + "| "
                + timesRented.ToString().PadRight(10, ' ') + "| "
                + copiesAvailable.ToString().PadRight(12, ' ') + "| ";
            return movieInfo;
        }

        public void BorrowMovie()
        {
            if (copiesAvailable > 0)
            {
                copiesAvailable -= 1;
            }
            else
            {
                throw new Exception("didnt work");
            }
        }

        public void ReturnMovie()
        {
            copiesAvailable += 1;
            timesRented += 1;
        }

        public bool notBeingRented()
        {
            if (copiesAvailable == copies)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
