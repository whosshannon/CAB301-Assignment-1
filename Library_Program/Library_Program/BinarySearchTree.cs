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
                    current = current.rChild;
                }
                else
                {
                    isLeftChild = false;
                    current = current.rChild;
                }
                //if (current == null) { return false; }
            }
            if ((current.lChild == null) & (current.rChild == null))
            {
                if (current == root)
                {
                    root = null;
                }
                else if (isLeftChild)
                {
                    parent.lChild = null;
                }
                else
                { 
                    parent.rChild = null;
                }
            }
        }
    }
}
