﻿using System;
namespace Library_Program
{
    class MainClass
    {
        static MovieCollection movieCollection;
        static MemberCollection memberCollection;

        public static void Main(string[] args)
        {
            movieCollection = new MovieCollection();
            memberCollection = new MemberCollection();
            memberCollection.FindMember("SmithJohn", "0000").Rent(movieCollection.SearchMovie("Harry Potter and the Philosopher's Stone"));
            memberCollection.FindMember("SmithJohn", "0000").Rent(movieCollection.SearchMovie("Harry Potter and the Chamber of Secrets"));
            memberCollection.FindMember("SmithJohn", "0000").Rent(movieCollection.SearchMovie("Harry Potter and the Prisoner of Azkaban"));

            string mainMenu = "Welcome to the Community Library!" +
                "\n" +
                "Main Menu".PadLeft(60, '=').PadRight(120, '=') +
                "\n 1.\t Staff login" +
                "\n 2.\t Member login" +
                "\n 0.\t Exit" +
                "\n".PadRight(121, '=') +
                "\n\nPlease make a selection (1-2, or 0 to exit)\n";            
            
            string input = "";

            while (input != "0")
            {
                input = "";

                Console.Clear();
                Console.WriteLine(mainMenu);
                input = Console.ReadLine();

                if (input == "0")
                {
                    //
                }
                else if (input == "1")
                {
                    //Staff
                    //ShowStaffMenu();
                    StaffLogin();
                }
                else if (input == "2")
                {
                    //Member
                    //MemberLogin();
                    ShowMemberMenu(memberCollection.FindMember("SmithJohn", "0000"));
                }
                else
                {
                    //Input unrecognised
                    ShowWrongInput();
                }
            }

        }

        public static void ShowWrongInput()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Community Library!" +
                "\n".PadRight(121, '=') +
                "\n Oops! Selection unrecognised" +
                "\n Please double check your selection" +
                "\n".PadRight(121, '=') +
                "\n\nPress any key to return to menu\n");

            Console.ReadKey();
        }

        public static void StaffLogin()
        {
            ShowStaffMenu();
        }

        /// <summary>
        /// Displays the Staff menu options until the user enters '0'
        /// </summary>
        public static void ShowStaffMenu()
        {
            string staffMenu = "Staff Menu".PadLeft(60, '=').PadRight(120, '=') +
                "\n 1.\t Add a new movie" +
                "\n 2.\t Remove a movie" +
                "\n 3.\t Register a new Member" +
                "\n 4.\t Find a registered member's phone number" +
                "\n 0.\t Return to main menu" +
                "\n".PadRight(121, '=') +
                "\n\nPlease make a selection (1-4, or 0 to return to main menu)\n";

            string input = "";

            while (input != "0")
            {
                input = "";

                Console.Clear();
                Console.WriteLine(staffMenu);
                input = Console.ReadLine();

                if (input == "0")
                {
                    //
                }
                else if (input == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Add a new movie");
                    Console.ReadKey();
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Remove a movie");
                    Console.ReadKey();
                }
                else if (input == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Register a new Member");
                    Console.ReadKey();
                }
                else if (input == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Find a registered member's phone number");
                    Console.ReadKey();
                }
                else
                {
                    //Input unrecognised
                    ShowWrongInput();
                }
            }
        }

        /// <summary>
        /// Shows screen for members to login
        /// </summary>
        public static void MemberLogin()
        {
            string input = "";

            while (input != "0")
            {
                input = "";

                Console.Clear();
                Console.WriteLine("Member Login".PadLeft(60, '=').PadRight(120, '='));
                Console.Write("Please enter your username:".PadRight(30, ' '));
                input = Console.ReadLine();
                Console.Write("Please enter your password:".PadRight(30, ' '));
                string password = Console.ReadLine();

                Member member = memberCollection.FindMember(input, password);


                if (member != null)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome " + member.GetFirstName() + "!");
                    Console.Read();
                    ShowMemberMenu(member);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Member Login".PadLeft(60, '=').PadRight(120, '='));
                    Console.Write("It looks like there isn't a " +
                        "\nuser with those details." +
                        "\n\nPress any key to try again " +
                        "\nor enter '0' to return to the main screen");
                    input = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Displays the Member menu until the user enters '0'
        /// </summary>
        /// <param name="member">The member who is logged in</param>
        public static void ShowMemberMenu(Member member)
        {
            string memberMenu = "Member Menu".PadLeft(60, '=').PadRight(120, '=') +
                "\n 1.\t Display all movies" +
                "\n 2.\t Borrow a movie" +
                "\n 3.\t Return a movie" +
                "\n 4.\t List current borrowed movies" +
                "\n 5.\t Display top 10 most popular movies" +
                "\n 0.\t Return to main menu" +
                "\n".PadRight(121, '=') +
                "\n\nPlease make a selection (1-5, or 0 to return to main menu)\n";

            string input = "";

            while (input != "0")
            {
                input = "";

                Console.Clear();
                Console.WriteLine(memberMenu);
                input = Console.ReadLine();

                if (input == "0")
                {
                    //User wishes to exit
                    break;
                }
                else if (input == "1")
                {
                    //List all movies in the library
                    Console.Clear();
                    Console.WriteLine("All movies in the library".PadLeft(90, '=').PadRight(179, '='));
                    movieCollection.ListAllMovies();
                    Console.ReadKey();
                }
                else if (input == "2")
                {
                    //Rent a movie
                    string input2 = "";

                    while (input2 != "0")
                    {
                        Console.Clear();
                        Console.WriteLine("Borrow a movie".PadLeft(60, '=').PadRight(120, '='));
                        Console.WriteLine("\nPlease enter the exact title of the movie you want to rent or enter '0' to return to menu\n");
                        Console.WriteLine("".PadRight(120, '='));
                        Console.Write("\nMovie title:\t");

                        input2 = Console.ReadLine();

                        if (input2 == "0" || input2 == null || input2 == "") { break; }

                        Movie movie = movieCollection.SearchMovie(input2);

                        if (movie == null)
                        {
                            ShowWrongInput();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Rent a movie".PadLeft(90, '=').PadRight(179, '=') + "\n" +
                                                movie.DisplayMovie() + "\n" + "".PadRight(179, '=') +
                                                "\n 1.\t Yes, this is the movie i want to rent" +
                                                "\n 2.\t No, i want to search again" +
                                                "\n 0.\t Return to menu" +
                                                "\n".PadRight(179, '=') +
                                                "\n\nPlease make a selection (1-2, or 0 to return to main menu)\n");
                            string response = Console.ReadLine();

                            if (response == "0")
                            {
                                //user wishes to exit
                                break;
                            }
                            else if (response == "1")
                            {
                                //rent the given movie
                                Console.Clear();
                                Console.WriteLine("Rent the movie");
                                member.Rent(movie);
                                Console.ReadKey();
                                input2 = "0";
                            }
                            else if (response == "2")
                            {
                                //the given movie is incorrect
                                Console.Clear();
                                Console.WriteLine("Dont rent the movie");
                                Console.ReadKey();
                            }
                            else
                            {
                                //input unrecognised
                                ShowWrongInput();
                            }
                        }
                    }
                }
                else if (input == "3")
                {
                    //Return a movie
                    string input2 = "";

                    while (input2 != "0")
                    {
                        Console.Clear();
                        Console.WriteLine("Return a movie".PadLeft(60, '=').PadRight(120, '='));

                        //Console.WriteLine(member.GetCurrentlyRenting());

                        Movie[] movies = member.GetCurrentlyRenting();

                        for (int i = 0; i < movies.Length; i++)
                        {
                            Console.WriteLine((i+1) + ".\t " + movies[i].GetTitle());
                        }

                        Console.WriteLine("\nWhich of your rented movies would you like to return?" +
                            "\nPlease make a selection or 0 to return to main menu");

                        //input2 = Console.ReadLine();

                        string response = Console.ReadLine();

                        if (response == "0")
                        {
                            break;
                        }
                        else if (int.TryParse(response, out int responseInt) && (responseInt <= movies.Length))
                        {
                            Console.Clear();
                            Console.WriteLine("Return " + response);
                            member.Return(movies[responseInt-1]);
                            Console.ReadKey();
                            input2 = "0";
                        }
                        else
                        {
                            ShowWrongInput();
                        }
                    }
                    
                }
                else if (input == "4")
                {
                    //List the movies the member is currently renting
                    Console.Clear();
                    Console.WriteLine("List current borrowed movies".PadLeft(60, '=').PadRight(120, '='));
                    Movie[] movies = member.GetCurrentlyRenting();
                    for (int i = 0; i < movies.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ".\t " + movies[i].GetTitle());
                    }
                    Console.ReadKey();
                }
                else if (input == "5")
                {
                    //Display the 10 movies that have been rented the most
                    Console.Clear();
                    Console.WriteLine("Display top 10 most popular movies".PadLeft(60, '=').PadRight(120, '='));
                    Console.ReadKey();
                }
                else
                {
                    //Input unrecognised
                    ShowWrongInput();
                }
            }
        }
    }
}
