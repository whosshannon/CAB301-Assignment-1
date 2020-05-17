using NUnit.Framework;
using System;

namespace Library_Program_Test
{
    [TestFixture()]
    public class MovieTest
    {
        string name = "Harry Potter and the Philosopher's Stone";
        string[] cast = { "Daniel Radcliffe", "Emma Watson", "Rupert Grint" };
        string director = "Chris Columbus";
        int runtime = 159;
        Library_Program.Movie.GenreType genre = Library_Program.Movie.GenreType.Adventuer;
        Library_Program.Movie.ClassificationType classification = Library_Program.Movie.ClassificationType.ParentalGuidance;
        int copies = 6;
        Library_Program.Movie harryPotter;

        [Test()]
        public void MovieObjectConstruction()
        {
            harryPotter = new Library_Program.Movie(name, cast, director, runtime, genre, classification, copies);
            Assert.That(harryPotter != null);
        }

        [Test()]
        public void MovieClassMember()
        {
            harryPotter = new Library_Program.Movie(name, cast, director, runtime, genre, classification, copies);
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
        Library_Program.Member john;

        [Test()]
        public void MemberObjectConstruction()
        {
            john = new Library_Program.Member(first, last, address, phone, password);
            Assert.That(john != null);
        }

        [Test()]
        public void MemberClassMember()
        {
            john = new Library_Program.Member(first, last, address, phone, password);
            Assert.That(john.GetPhone() == 0123456789);
        }
    }


    [TestFixture()]
    public class BinarySearchTreeTest
    {
        Library_Program.BinarySearchTree bst;

        [Test()]
        public void BSTObjectConstruction()
        {
            bst = new Library_Program.BinarySearchTree();
            Assert.That(bst != null);
        }

        [Test()]
        public void BSTInsert()
        {
            bst = new Library_Program.BinarySearchTree();
            bst.Insert("MOVIE");
            Assert.That(bst.root.value == "MOVIE");
        }

        [Test()]
        public void BSTMultipleInsert()
        {
            bst = new Library_Program.BinarySearchTree();
            bst.Insert("D");
            bst.Insert("B");
            bst.Insert("A");
            bst.Insert("C");
            bst.Insert("F");
            bst.Insert("G");
            bst.Insert("E");
            bst.Insert("H");

            bool d = bst.root.value == "D";
            bool b = bst.root.lChild.value == "B";
            bool a = bst.root.lChild.lChild.value == "A";
            bool c = bst.root.lChild.rChild.value == "C";
            bool f = bst.root.rChild.value == "F";
            bool g = bst.root.rChild.rChild.value == "G";
            bool e = bst.root.rChild.lChild.value == "E";
            bool h = bst.root.rChild.rChild.rChild.value == "H";

            Assert.That(a && b && c & d && e && f && g && h);

        }

        [Test()]
        public void BSTSearch()
        {
            bst = new Library_Program.BinarySearchTree();
            bst.Insert("D");
            bst.Insert("B");
            bst.Insert("A");
            bst.Insert("C");
            bst.Insert("F");
            bst.Insert("G");
            bst.Insert("E");
            bst.Insert("H");

            Assert.That(bst.Search("D") == bst.root);
        }

        [Test()]
        public void BSTSearchMultiple()
        {
            bst = new Library_Program.BinarySearchTree();
            bst.Insert("D");
            bst.Insert("B");
            bst.Insert("A");
            bst.Insert("C");
            bst.Insert("F");
            bst.Insert("G");
            bst.Insert("E");
            bst.Insert("H");

            Assert.That(bst.Search("H") == bst.root.rChild.rChild.rChild);
        }

        [Test()]
        public void BSTSearchEmptyFail()
        {
            bst = new Library_Program.BinarySearchTree();
            
            Assert.That(bst.Search("S").value == "-1");
        }
        [Test()]
        public void BSTSearchFail()
        {
            bst = new Library_Program.BinarySearchTree();
            bst.Insert("D");
            bst.Insert("B");
            bst.Insert("A");
            bst.Insert("C");
            bst.Insert("F");
            bst.Insert("G");
            bst.Insert("E");
            bst.Insert("H");

            Assert.That(bst.Search("S").value == "-1");
        }

        [Test()]
        public void BSTDeleteLeaf()
        {
            bst = new Library_Program.BinarySearchTree();
            bst.Insert("D");
            bst.Insert("B");
            bst.Insert("A");
            bst.Insert("C");
            bst.Insert("F");
            bst.Insert("G");
            bst.Insert("E");
            bst.Insert("H");

            bst.Delete("H");

            Assert.That(bst.Search("H").value == "-1");

        }

        [Test()]
        public void BSTDeleteNodeWithOneChildOriginalDeleted()
        {
            bst = new Library_Program.BinarySearchTree();
            bst.Insert("D");
            bst.Insert("B");
            bst.Insert("A");
            bst.Insert("C");
            bst.Insert("F");
            bst.Insert("G");
            bst.Insert("E");
            bst.Insert("H");

            bst.Delete("G");

            Assert.That(bst.Search("G").value == "-1");

        }

        [Test()]
        public void BSTDeleteNodeWithOneChildChildUpdated()
        {
            bst = new Library_Program.BinarySearchTree();
            bst.Insert("D");
            bst.Insert("B");
            bst.Insert("A");
            bst.Insert("C");
            bst.Insert("F");
            bst.Insert("G");
            bst.Insert("E");
            bst.Insert("H");

            bst.Delete("G");

            Assert.That(bst.root.rChild.rChild.value == "H");

        }

        [Test()]
        public void BSTDeleteNodeWithTwoChildrenOrginalReplaced()
        {
            bst = new Library_Program.BinarySearchTree();
            bst.Insert("D");
            bst.Insert("B");
            bst.Insert("A");
            bst.Insert("C");
            bst.Insert("F");
            bst.Insert("E");
            bst.Insert("I");
            bst.Insert("H");
            bst.Insert("G");
            bst.Insert("J");

            bst.Delete("I");

            Assert.That(bst.root.rChild.rChild.value == "H");

        }

        [Test()]
        public void BSTDeleteNodeWithTwoChildrenchildrenUpdated()
        {
            bst = new Library_Program.BinarySearchTree();
            bst.Insert("D");
            bst.Insert("B");
            bst.Insert("A");
            bst.Insert("C");
            bst.Insert("F");
            bst.Insert("E");
            bst.Insert("I");
            bst.Insert("H");
            bst.Insert("G");
            bst.Insert("J");

            bst.Delete("I");

            Assert.That(bst.root.rChild.rChild.lChild.value == "G");

        }
    }
}
