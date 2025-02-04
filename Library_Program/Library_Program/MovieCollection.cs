﻿using System;
namespace Library_Program
{
    public class MovieCollection
    {
        BinarySearchTree movieBST;

        public MovieCollection()
        {
            movieBST = new BinarySearchTree();
            Populate();
        }

        public void Populate()
        {
            string name = "Harry Potter and the Philosopher's Stone";
            string cast = "Daniel Radcliffe";
            string director = "Chris Columbus";
            int runtime = 159;
            Movie.GenreType genre = Movie.GenreType.Adventure;
            Movie.ClassificationType classification = Movie.ClassificationType.ParentalGuidance;
            DateTime date = new DateTime(2001, 11, 16);
            int copies = 6;
            movieBST.Insert(new Movie(name, cast, director, runtime, genre, classification, date, copies));

            name = "Harry Potter and the Chamber of Secrets";
            runtime = 161;
            date = new DateTime(2002, 11, 15);
            movieBST.Insert(new Movie(name, cast, director, runtime, genre, classification, date, copies));

            name = "Harry Potter and the Prisoner of Azkaban";
            runtime = 142;
            director = "Alfonso Cuaron";
            date = new DateTime(2004, 5, 31);
            movieBST.Insert(new Movie(name, cast, director, runtime, genre, classification, date, copies));

            name = "Harry Potter and the Goblet of Fire";
            runtime = 157;
            director = "Mike Newell";
            classification = Movie.ClassificationType.Mature;
            date = new DateTime(2005, 11, 18);
            movieBST.Insert(new Movie(name, cast, director, runtime, genre, classification, date, copies));

            name = "Harry Potter and the Order of the Phoenix";
            runtime = 138;
            director = "David Yates";
            date = new DateTime(2007, 7, 12);
            movieBST.Insert(new Movie(name, cast, director, runtime, genre, classification, date, copies));

            name = "Harry Potter and the Half-Blood Prince";
            runtime = 153;
            date = new DateTime(2009, 7, 15);
            movieBST.Insert(new Movie(name, cast, director, runtime, genre, classification, date, copies));

            name = "Harry Potter and the Deathly Hallows: Part 1";
            runtime = 147;
            date = new DateTime(2010, 11, 19);
            movieBST.Insert(new Movie(name, cast, director, runtime, genre, classification, date, copies));

            name = "Harry Potter and the Deathly Hallows: Part 2";
            runtime = 130;
            date = new DateTime(2011, 7, 15);
            movieBST.Insert(new Movie(name, cast, director, runtime, genre, classification, date, copies));

        }

        public void AddMovie(Movie movie)
        {
            movieBST.Insert(movie);
        }

        public void RemoveMovie(Movie movie)
        {
            movieBST.Delete(movie);
        }

        public void ListAllMovies()
        {
            string movieInfoHeader = "Movie title".PadRight(50, ' ') + "| "
                + "Starring".PadRight(20, ' ') + "| "
                + "Directed by".PadRight(20, ' ') + "| "
                + "Run time".PadRight(10, ' ') + "| "
                + "Genre".PadRight(10, ' ') + "| "
                + "Classification".PadRight(18, ' ') + "| "
                + "Release Date".PadRight(12, ' ') + "| "
                + "# Rented".ToString().PadRight(10, ' ') + "| "
                + "# Available".ToString().PadRight(12, ' ') + "| ";
            Console.WriteLine(movieInfoHeader);
            Console.WriteLine("".PadRight(180, '='));
            movieBST.List();
        }

        public Movie SearchMovie(string data)
        {
            return movieBST.Search(data);
        }

        public void TopTenMovies()
        {
            //traverse BST and transform into an array
            Movie[] movieArray = movieBST.InOrder(movieBST.GetRoot());
            //sort array by # borrowed using mergesort
            movieArray = MergeSort(movieArray);
            //print? i guess
            foreach (Movie movie in movieArray)
            {
                if (movie != null)
                {
                    Console.WriteLine(movie.DisplayMovie());
                }
            }
        }

        Movie[] MergeSort(Movie[] movieArray) {
            if (1 < movieArray.Length)
            {
                int leftLength = movieArray.Length / 2;
                int rightLength = movieArray.Length - leftLength;

                Movie[] left = new Movie[leftLength];
                Movie[] right = new Movie[rightLength];

                for (int i = 0; i < leftLength; i++)
                {
                    left[i] = movieArray[i];
                }

                for (int i = 0; i < rightLength; i++)
                {
                    right[i] = movieArray[rightLength + i];
                }

                left = MergeSort(left);
                right = MergeSort(right);


                movieArray = Merge(left, right);

                return movieArray;
            }
            else
            {
                return movieArray;
            }
        }

        Movie[] Merge(Movie[] left, Movie[] right)
        {
            Movie[] movieArray = new Movie[left.Length + right.Length];

            int leftIndex = 0;
            int rightIndex = 0;
            int outIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] == null) { leftIndex++; }
                else if (right[rightIndex] == null) { rightIndex++; }
                else if (left[leftIndex].GetTimesRented() >= right[rightIndex].GetTimesRented())
                {
                    movieArray[outIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    movieArray[outIndex] = right[rightIndex];
                    rightIndex++;
                }
                outIndex++;
            }

            while (leftIndex < left.Length)
            {
                movieArray[outIndex] = left[leftIndex];
                leftIndex++;
                outIndex++;
            }
            while(rightIndex < right.Length)
            {
                movieArray[outIndex] = right[rightIndex];
                rightIndex++;
                outIndex++;
            }

            return movieArray;
        }
    }
}
