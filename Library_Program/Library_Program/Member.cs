using System;
using System.Collections;
namespace Library_Program

{
    public class Member
    {
        string first;
        string last;
        string address;
        int phone;
        ArrayList currentlyRenting;
        string username;
        string password;

        public Member(string firstName, string Lastname, string residentialAddress, int phoneNumer, string pass)
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

        public int GetPhone()
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

        public string GetCurrentlyRenting()
        {
            string currentlyRentingMovies = "";
            foreach (Movie movie in currentlyRenting)
            {
                currentlyRentingMovies += "\t" + movie.GetTitle() + "\n";
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
