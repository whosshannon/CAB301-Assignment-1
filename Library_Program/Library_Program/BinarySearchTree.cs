using System;
namespace Library_Program
{
    public class BinarySearchTree
    {
        public class Node
        {
            public Movie value;
            public Node lChild;
            public Node rChild;
        }

        public Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        /// <summary>
        /// Inserts a new Movie into the Binary Search Tree
        /// </summary>
        /// <param name="data">The value that you would like to insert into the BST</param>
        public void Insert(Movie data)
        {
            Node newNode = new Node();
            newNode.value = data;

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node current = root;
                Node parent;
                bool searching = true;

                while (searching)
                {
                    parent = current;
                    if (string.Compare(newNode.value.GetTitle(), current.value.GetTitle()) == -1)
                    {
                        current = current.lChild;
                        if (current == null)
                        {
                            parent.lChild = newNode;
                            searching = false;
                        }
                    }
                    else if (string.Compare(newNode.value.GetTitle(), current.value.GetTitle()) == 1)
                    {
                        current = current.rChild;
                        if (current == null)
                        {
                            parent.rChild = newNode;
                            searching = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Searches for a movie within the BST given the title
        /// </summary>
        /// <param name="data">The title of the movie</param>
        /// <returns>Returns a node corresponding to the searched value, node has value of "-1" if search is unsuccessfull</returns>
        public Movie Search(string data)
        {
            Node position = new Node();

            if (root == null)
            {
                return null;
            }

            if (root.value.GetTitle() == data)
            {
                position = root;
                return position.value;
            }
            else
            {
                Node current = root;
                Node parent;
                bool searching = true;

                while (searching)
                {
                    parent = current;
                    if (string.Compare(data, current.value.GetTitle()) == -1)
                    {
                        if (current.lChild != null)
                        {
                            current = current.lChild;
                            if (current.value.GetTitle() == data)
                            {
                                position = current;
                                return position.value;
                            }
                            else if (current.lChild == null && current.rChild == null)
                            {
                                searching = false;
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (string.Compare(data, current.value.GetTitle()) == 1)
                    {
                        if (current.rChild != null)
                        {
                            current = current.rChild;
                            if (current.value.GetTitle() == data)
                            {
                                position = current;
                                return position.value;
                            }
                            else if (current.lChild == null && current.rChild == null)
                            {
                                searching = false;
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Deletes a Movie from the given BST
        /// </summary>
        /// <param name="data">the Movie of the node to be deleted</param>
        public void Delete(Movie data)
        {
            Node current = root;
            Node parent = root;
            bool isLeftChild = true;
            while (current.value != data)
            {
                parent = current;
                if (string.Compare(data.GetTitle(), current.value.GetTitle()) == -1)
                {
                    isLeftChild = true;
                    current = current.lChild;
                }
                else
                {
                    isLeftChild = false;
                    current = current.rChild;
                }
                //if (current == null) { return false; }
            }

            if (current.lChild == null && current.rChild == null)
            {
                //node to be deleted is a leaf
                if (isLeftChild)
                {
                    parent.lChild = null;
                }
                else
                {
                    parent.rChild = null;
                }
            }
            else if (current.lChild != null && current.rChild == null)
            {
                //node to be deleted has one left child
                if (isLeftChild)
                {
                    parent.lChild = current.lChild;
                }
                else
                {
                    parent.rChild = current.lChild;
                }
            }
            else if (current.lChild == null && current.rChild != null)
            {
                //node to be deleted has one right child
                if (isLeftChild)
                {
                    parent.lChild = current.rChild;
                }
                else
                {
                    parent.rChild = current.rChild;
                }
            }
            else if (current.lChild != null && current.rChild != null)
            {
                //node to be deleted has two children
                Node rightmostOfLeft = current.lChild;
                bool lowest = false;

                while (!lowest)
                {
                    if (rightmostOfLeft.rChild != null)
                    {
                        rightmostOfLeft = rightmostOfLeft.rChild;
                    }
                    else
                    {
                        lowest = true;
                    }
                }

                Node placeholder = rightmostOfLeft;

                Delete(rightmostOfLeft.value);

                if (isLeftChild)
                {
                    parent.lChild.value = placeholder.value;
                }
                else
                {
                    parent.rChild.value = placeholder.value;
                }
            }
        }

        public Node GetRoot()
        {
            return root;
        }

        public int GetLength(Node tNode)
        {
            int length = 0;
            if (tNode != null)
            {
                length += GetLength(tNode.lChild);
                if (tNode != null)
                {
                    length++;
                }
                length += GetLength(tNode.rChild);
            }
            return length;
        }

        public void List()
        {
            //in order traversal
            Movie[] movieArray = InOrder(root);
            foreach (Movie movie in movieArray)
            {
                Console.WriteLine(movie.DisplayMovie());
            }
        }

        public Movie[] InOrder(Node tNode)
        {
            Movie[] movieArray = new Movie[GetLength(root)];
            int index = 0;

            if (tNode != null)
            {
                foreach (Movie movie in InOrder(tNode.lChild))
                {
                    if (movie != null) { movieArray[index++] = movie;}
                }

                movieArray[index++] = tNode.value;

                foreach (Movie movie in InOrder(tNode.rChild))
                {
                    if (movie != null) { movieArray[index++] = movie; }
                }
            }

            //int j = 0;

            //for (int i = 0; i < movieArray.Length; i++)
            //{
            //    if (movieArray[i] != null)
            //    {
            //        j++;
            //    }
            //}

            //Movie[] newMovieArray = new Movie[j];
            //int k = 0;

            //for (int i = 0; i < movieArray.Length; i++)
            //{
            //    if (movieArray[i] != null)
            //    {
            //        newMovieArray[k] = movieArray[i];
            //        k++;
            //    }
            //}

            //return newMovieArray;
            return movieArray;
        }

    }
}
