using NUnit.Framework;
using System;
using System.Collections;    
using Library_Program;


namespace Library_Program_Test
{
    [TestFixture()]
    public class MovieTest
    {
        string name = "Harry Potter and the Philosopher's Stone";
        string cast = "Daniel Radcliffe";
        string director = "Chris Columbus";
        int runtime = 159;
        Movie.GenreType genre = Movie.GenreType.Adventure;
        Movie.ClassificationType classification = Movie.ClassificationType.ParentalGuidance;
        DateTime date = new DateTime(2001, 11, 16);
        int copies = 6;
        Movie harryPotter;

        [SetUp()]
        public void Setup()
        {
            harryPotter = new Movie(name, cast, director, runtime, genre, classification, date, copies);
        }

        [Test()]
        public void MovieObjectConstruction()
        {
            Assert.That(harryPotter != null);
        }

        [Test()]
        public void MovieClassMember()
        {
            Assert.That(harryPotter.GetTitle() == "Harry Potter and the Philosopher's Stone");
        }
    }


    [TestFixture()]
    public class MemberTest
    {
        string first = "John";
        string last = "Doe";
        string address = "1 Main Road, Brisbane";
        int phone = 0123456789;
        string password = "1234";
        Member john;

        string name = "Harry Potter and the Philosopher's Stone";
        string cast = "Daniel Radcliffe";
        string director = "Chris Columbus";
        int runtime = 159;
        Movie.GenreType genre = Movie.GenreType.Adventure;
        Movie.ClassificationType classification = Movie.ClassificationType.ParentalGuidance;
        DateTime date = new DateTime(2001, 11, 16);
        int copies = 6;
        Movie harryPotter;

        [SetUp()]
        public void Setup()
        {
            john = new Member(first, last, address, phone, password);
            harryPotter = new Movie(name, cast, director, runtime, genre, classification, date, copies);
        }

        [Test()]
        public void MemberObjectConstruction()
        {
            Assert.That(john != null);
        }

        [Test()]
        public void MemberGetPhone()
        {
            Assert.That(john.GetPhone() == 0123456789);
        }

        [Test()]
        public void MemberGetFirstname()
        {
            Assert.That(john.GetFirstName() == "John");
        }

        [Test()]
        public void MemberGetLastname()
        {
            Assert.That(john.GetLastName() == "Doe");
        }

        [Test()]
        public void MemberGetUsername()
        {
            Assert.That(john.GetUsername() == "DoeJohn");
        }

        [Test()]
        public void MemberGetPassword()
        {
            Assert.That(john.GetPassword() == "1234");
        }

        //[Test()]
        //public void MemberRent()
        //{
        //    ArrayList expectedList = new ArrayList();
        //    expectedList.Add(harryPotter);

        //    john.Rent(harryPotter);

        //    bool equal = true;

        //    if (expectedList.Count != john.GetCurrentlyRenting().Count)
        //    {
        //        equal = false;
        //    }
        //    for (int i = 0; i < expectedList.Count; i++)
        //    {
        //        if (!expectedList[i].Equals(john.GetCurrentlyRenting()[i]))
        //        {
        //            equal = false;
        //        }
        //    }

        //    Assert.That(equal);
        //}

        //[Test()]
        //public void MemberReturn()
        //{
        //    ArrayList expectedList = new ArrayList();
        //    //expectedList.Add(harryPotter);

        //    john.Rent(harryPotter);
        //    john.Return(harryPotter);

        //    bool equal = true;

        //    if (expectedList.Count != john.GetCurrentlyRenting().Count)
        //    {
        //        equal = false;
        //    }
        //    for (int i = 0; i < expectedList.Count; i++)
        //    {
        //        if (!expectedList[i].Equals(john.GetCurrentlyRenting()[i]))
        //        {
        //            equal = false;
        //        }
        //    }

        //    Assert.That(equal);
        //}

        [Test()]
        public void MemberRent()
        {
            ArrayList expectedList = new ArrayList();
            expectedList.Add(harryPotter);

            john.Rent(harryPotter);

            string currentlyRentingMovies = "";
            foreach (Movie movie in expectedList)
            {
                currentlyRentingMovies += movie.GetTitle() + ", ";
            }

            string johnMovies = "";
            foreach (Movie movie in john.GetCurrentlyRenting()) {
                johnMovies += movie.GetTitle() + ", ";
            }

            Assert.That(johnMovies == currentlyRentingMovies);
        }

        [Test()]
        public void MemberReturn()
        {
            ArrayList expectedList = new ArrayList();
            //expectedList.Add(harryPotter);

            john.Rent(harryPotter);
            john.Return(harryPotter);

            string currentlyRentingMovies = "";
            foreach (Movie movie in expectedList)
            {
                currentlyRentingMovies += movie.GetTitle() + ", ";
            }

            string johnMovies = "";
            foreach (Movie movie in john.GetCurrentlyRenting())
            {
                johnMovies += movie.GetTitle() + ", ";
            }

            Assert.That(johnMovies == currentlyRentingMovies);
        }
    }


    [TestFixture()]
    public class BinarySearchTreeTest
    {
        BinarySearchTree bst;

        string cast = "";
        string director = "";
        int runTime = 0;
        Movie.GenreType givenGenre = 0;
        Movie.ClassificationType givenClassification = 0;
        DateTime date = new DateTime(2000, 09, 12);
        int numberOfCopies = 0;

        Movie A, B, C, D, E, F, G, H, I, J, Ee;

        [SetUp()]
        public void Setup()
        {
            A = new Movie("A", cast, director, runTime, givenGenre, givenClassification, date, numberOfCopies);
            B = new Movie("B", cast, director, runTime, givenGenre, givenClassification, date, numberOfCopies);
            C = new Movie("C", cast, director, runTime, givenGenre, givenClassification, date, numberOfCopies);
            D = new Movie("D", cast, director, runTime, givenGenre, givenClassification, date, numberOfCopies);
            E = new Movie("E", cast, director, runTime, givenGenre, givenClassification, date, numberOfCopies);
            Ee = new Movie("Ee", cast, director, runTime, givenGenre, givenClassification, date, numberOfCopies);
            F = new Movie("F", cast, director, runTime, givenGenre, givenClassification, date, numberOfCopies);
            G = new Movie("G", cast, director, runTime, givenGenre, givenClassification, date, numberOfCopies);
            H = new Movie("H", cast, director, runTime, givenGenre, givenClassification, date, numberOfCopies);
            I = new Movie("I", cast, director, runTime, givenGenre, givenClassification, date, numberOfCopies);
            J = new Movie("J", cast, director, runTime, givenGenre, givenClassification, date, numberOfCopies);

            bst = new BinarySearchTree();
            bst.Insert(D);
            bst.Insert(B);
            bst.Insert(A);
            bst.Insert(C);
            bst.Insert(F);
            bst.Insert(E);
            bst.Insert(I);
            bst.Insert(Ee);
            bst.Insert(H);
            bst.Insert(G);
            bst.Insert(J);
        }

        [Test()]
        public void BSTObjectConstruction()
        {
            Assert.That(bst != null);
        }

        [Test()]
        public void BSTInsert()
        {
            Assert.That(bst.root.value.GetTitle() == "D");
        }

        [Test()]
        public void BSTMultipleInsert()
        {
            bool d = bst.root.value.GetTitle() == "D";
            bool b = bst.root.lChild.value.GetTitle() == "B";
            bool a = bst.root.lChild.lChild.value.GetTitle() == "A";
            bool c = bst.root.lChild.rChild.value.GetTitle() == "C";
            bool f = bst.root.rChild.value.GetTitle() == "F";
          
            Assert.That(a && b && c & d && f);

        }

        [Test()]
        public void BSTSearch()
        {
            Assert.That(bst.Search("D") == bst.root.value);
        }

        [Test()]
        public void BSTSearchEmptyFail()
        {
            Assert.That(bst.Search("S") == null);
        }
        [Test()]
        public void BSTSearchFail()
        {
            Assert.That(bst.Search("S") == null);
        }

        [Test()]
        public void BSTDeleteLeaf()
        {
            bst.Delete(H);

            Assert.That(bst.Search("H") == null);

        }

        [Test()]
        public void BSTDeleteNodeWithOneChildOriginalDeleted()
        {
            bst.Delete(H);

            Assert.That(bst.Search("H") == null);

        }

        [Test()]
        public void BSTDeleteNodeWithOneChildChildUpdated()
        {
            bst.Delete(H);

            Assert.That(bst.root.rChild.rChild.value.GetTitle() == "I");

        }

        [Test()]
        public void BSTDeleteNodeWithTwoChildrenOrginalReplaced()
        {
            bst.Delete(F);

            Assert.That(bst.root.rChild.value.GetTitle() == "Ee");

        }

        [Test()]
        public void BSTDeleteNodeWithTwoChildrenRightmostLeftDelted()
        {
            Console.WriteLine("hello" + bst.root.rChild.lChild.rChild.value.GetTitle());

            bst.Delete(F);
            Console.WriteLine("hello");

            //Console.WriteLine("hello"+bst.root.rChild.lChild.rChild.value.GetTitle());

            Assert.That(bst.root.rChild.lChild.rChild.value == null);

        }

        [Test()]
        public void BSTDeleteNodeWithTwoChildrenLeftChildrenUpdated()
        {
            bst.Delete(F);

            Assert.That(bst.root.rChild.lChild.value.GetTitle() == "E");

        }

        [Test()]
        public void BSTDeleteNodeWithTwoChildrenRightChildrenUpdated()
        {
            bst.Delete(F);

            Assert.That(bst.root.rChild.rChild.value.GetTitle() == "I");

        }

        [Test()]
        public void BSTList()
        {
            bst.List();
            Assert.That(1 != 2);
        }
    }

    [TestFixture()]
    public class MovieCollectionTest
    {
        MovieCollection movieCollection;

        [SetUp()]
        public void Setup()
        {
            movieCollection = new MovieCollection();
        }

        [Test()]
        public void MovieCollectionObjectConstruction()
        {
            Assert.That(movieCollection != null);
        }

        [Test()]
        public void MovieCollectionClassMember()
        {
            movieCollection.ListAllMovies();
            Assert.That(movieCollection != null);
        }

        //[Test()]
        //public void a()
        //{
        //    //
        //}

        //[Test()]
        //public void a()
        //{
        //    //
        //}

        //[Test()]
        //public void a()
        //{
        //    //
        //}

        //[Test()]
        //public void a()
        //{
        //    //
        //}
    }
}
