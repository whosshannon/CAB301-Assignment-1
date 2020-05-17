using System;
namespace Library_Program
{
    public class BinarySearchTree
    {
        public class Node
        {
            public string value;
            public Node lChild;
            public Node rChild;
        }

        public Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        /// <summary>
        /// Inserts a new value into the Binary Search Tree
        /// </summary>
        /// <param name="data">The value that you would like to insert into the BST</param>
        public void Insert(string data)
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
                    if (string.Compare(newNode.value, current.value) == -1)
                    {
                        current = current.lChild;
                        if (current == null)
                        {
                            parent.lChild = newNode;
                            searching = false;
                        }
                    }
                    else if (string.Compare(newNode.value, current.value) == 1)
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
        /// Searches for a value within the BST
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Returns a node corresponding to the searched value, node has value of "-1" if search is unsuccessfull</returns>
        public Node Search(string data)
        {
            Node position = new Node();

            if (root == null)
            {
                position.value = "-1";
                return position;
            }

            if (root.value == data)
            {
                position = root;
                return position;
            }
            else
            {
                Node current = root;
                Node parent;
                bool searching = true;

                while (searching)
                {
                    parent = current;
                    if (string.Compare(data, current.value) == -1)
                    {
                        current = current.lChild;
                        if (current.value == data)
                        {
                            position = current;
                            return position;
                        }
                        else if (current.lChild == null && current.rChild == null)
                        {
                            searching = false;
                        }
                    }
                    else if (string.Compare(data, current.value) == 1)
                    {
                        current = current.rChild;
                        if (current.value == data)
                        {
                            position = current;
                            return position;
                        }
                        else if (current.lChild == null && current.rChild == null)
                        {
                            searching = false;
                        }
                    }
                }
            }
            position.value = "-1";
            return position;
        }

        /// <summary>
        /// Deletes a value from the given BST
        /// </summary>
        /// <param name="data">the value of the node to be deleted</param>
        public void Delete(string data)
        {
            Node current = root;
            Node parent = root;
            bool isLeftChild = true;
            while (current.value != data)
            {
                parent = current;
                if (string.Compare(data, current.value) == -1)
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

                Delete(rightmostOfLeft.value);

                if (isLeftChild)
                {
                    parent.lChild = rightmostOfLeft;
                }
                else
                {
                    parent.rChild = rightmostOfLeft;

                }
            }
        }
    }
}
