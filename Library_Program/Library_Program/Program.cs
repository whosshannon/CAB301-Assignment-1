using System;
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

            string mainMenu = "Welcome to the Community Library!" +
                "\n===========Main Menu============" +
                "\n 1.\t Staff login" +
                "\n 2.\t Member login" +
                "\n 0.\t Exit" +
                "\n================================" +
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
                    ShowStaffMenu();
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
                "\n================================" +
                "\n Oops! Selection unrecognised" +
                "\n Please double check your selection" +
                "\n================================" +
                "\n\nPress any key to return to menu\n");

            Console.ReadKey();
        }

        /// <summary>
        /// Displays the Staff menu options until the user enters '0'
        /// </summary>
        public static void ShowStaffMenu()
        {
            string staffMenu = "===========Staff Menu===========" +
                "\n 1.\t Add a new movie" +
                "\n 2.\t Remove a movie" +
                "\n 3.\t Register a new Member" +
                "\n 4.\t Find a registered member's phone number" +
                "\n 0.\t Return to main menu" +
                "\n================================" +
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

        public static void MemberLogin()
        {
            string input = "";

            while (input != "0")
            {
                input = "";

                Console.Clear();
                Console.WriteLine("===========Member Login==========");
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
                    Console.WriteLine("===========Member Login==========");
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
        public static void ShowMemberMenu(Member member)
        {
            string memberMenu = "===========Member Menu==========" +
                "\n 1.\t Display all movies" +
                "\n 2.\t Borrow a movie" +
                "\n 3.\t Return a movie" +
                "\n 4.\t List current borrowed movies" +
                "\n 5.\t Display top 10 most popular movies" +
                "\n 0.\t Return to main menu" +
                "\n================================" +
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
                    break;
                }
                else if (input == "1")
                {
                    Console.Clear();
                    movieCollection.ListAllMovies();
                    Console.ReadKey();
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Borrow a movie");
                    Console.ReadKey();
                }
                else if (input == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Return a movie");
                    Console.ReadKey();
                }
                else if (input == "4")
                {
                    Console.Clear();
                    Console.WriteLine("List current borrowed movies");
                    Console.ReadKey();
                }
                else if (input == "5")
                {
                    Console.Clear();
                    Console.WriteLine("Display top 10 most popular movies");
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
