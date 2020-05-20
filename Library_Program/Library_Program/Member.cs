using System;
using System.Collections;
namespace Library_Program

{
    public class Member
    {
        string first;
        string last;
        string address;
        string phone;
        ArrayList currentlyRenting;
        string username;
        string password;

        public Member(string firstName, string Lastname, string residentialAddress, string phoneNumer, string pass)
        {
            currentlyRenting = new ArrayList();
            first = firstName;
            last = Lastname;
            address = residentialAddress;
            phone = phoneNumer;
            username = last + first;

            int tryPassword;
            if ((!int.TryParse(pass, out tryPassword)) || pass.Length != 4)
            {
                //reject application
            }
            else
            {
                password = pass;
            }
        }

        public string GetPhone()
        {
            return phone;
        }

        public string GetFirstName()
        {
            return first;
        }

        public string GetLastName()
        {
            return last;
        }

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        //public String GetCurrentlyRenting()
        //{
        //    string currentlyRentingMovies = "";
        //    int i = 1;

        //    foreach (Movie movie in currentlyRenting)
        //    {
        //        currentlyRentingMovies += "\n " + i + ".\t " + movie.GetTitle();
        //        i += 1;
        //    }

        //    return currentlyRentingMovies;
        //}

        public Movie[] GetCurrentlyRenting()
        {
            Movie[] currentlyRentingMovies = new Movie[currentlyRenting.Count];
            int i = 0;

            foreach (Movie movie in currentlyRenting)
            {
                currentlyRentingMovies[i] = movie;
                i += 1;
            }


            return currentlyRentingMovies;
        }

        public void Rent(Movie movie)
        {
            if (!currentlyRenting.Contains(movie))
            {
                currentlyRenting.Add(movie);
                movie.BorrowMovie();
            }
        }

        public void Return(Movie movie)
        {
            if (currentlyRenting.Contains(movie))
            {
                currentlyRenting.Remove(movie);
                movie.ReturnMovie();
            }
        }
    }
}
