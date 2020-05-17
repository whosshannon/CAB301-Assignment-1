using NUnit.Framework;
using System;
using Library_Program;


namespace Library_Program_Test
{
    [TestFixture()]
    public class MovieTest
    {
        string name = "Harry Potter and the Philosopher's Stone";
        string[] cast = { "Daniel Radcliffe", "Emma Watson", "Rupert Grint" };
        string director = "Chris Columbus";
        int runtime = 159;
        Movie.GenreType genre = Movie.GenreType.Adventuer;
        Movie.ClassificationType classification = Movie.ClassificationType.ParentalGuidance;
        int copies = 6;
        Movie harryPotter;

        [SetUp()]
        public void Setup()
        {
            harryPotter = new Movie(name, cast, director, runtime, genre, classification, copies);
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
        int password = 1234;
        Member john;

        [Test()]
        public void MemberObjectConstruction()
        {
            john = new Member(first, last, address, phone, password);
            Assert.That(john != null);
        }

        [Test()]
        public void MemberClassMember()
        {
            john = new Member(first, last, address, phone, password);
            Assert.That(john.GetPhone() == 0123456789);
        }
    }


    [TestFixture()]
    public class BinarySearchTreeTest
    {
        BinarySearchTree bst;

        string[] cast = {""};
        string director = "";
        int runTime = 0;
        Movie.GenreType givenGenre = 0;
        Movie.ClassificationType givenClassification = 0;
        int numberOfCopies = 0;

        Movie A, B, C, D, E, F, G, H, I, J;

        [SetUp()]
        public void Setup()
        {
            A = new Movie("A", cast, director, runTime, givenGenre, givenClassification, numberOfCopies);
            B = new Movie("B", cast, director, runTime, givenGenre, givenClassification, numberOfCopies);
            C = new Movie("C", cast, director, runTime, givenGenre, givenClassification, numberOfCopies);
            D = new Movie("D", cast, director, runTime, givenGenre, givenClassification, numberOfCopies);
            E = new Movie("E", cast, director, runTime, givenGenre, givenClassification, numberOfCopies);
            F = new Movie("F", cast, director, runTime, givenGenre, givenClassification, numberOfCopies);
            G = new Movie("G", cast, director, runTime, givenGenre, givenClassification, numberOfCopies);
            H = new Movie("H", cast, director, runTime, givenGenre, givenClassification, numberOfCopies);
            I = new Movie("I", cast, director, runTime, givenGenre, givenClassification, numberOfCopies);
            J = new Movie("J", cast, director, runTime, givenGenre, givenClassification, numberOfCopies);

            bst = new BinarySearchTree();
            bst.Insert(D);
            bst.Insert(B);
            bst.Insert(A);
            bst.Insert(C);
            bst.Insert(F);
            bst.Insert(E);
            bst.Insert(I);
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
            Assert.That(bst.Search("D") == bst.root);
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
            bst.Delete(I);

            Assert.That(bst.root.rChild.rChild.value.GetTitle() == "H");

        }

        [Test()]
        public void BSTDeleteNodeWithTwoChildrenchildrenUpdated()
        {
            bst.Delete(I);

            Assert.That(bst.root.rChild.rChild.lChild.value.GetTitle() == "G");

        }
    }
}
