using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeNamespace
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public Node(int val)
        {
            this.data = val;
            this.left = null;
            this.right = null;
        }
    }
    class BinarySearchTree
    {
        Node root;
        BinarySearchTree()
        {
            this.root = null;
        }

        bool Find(int val)
        {
            Node current = this.root;
            bool found = false;
            if (current == null) return false;
            while (current != null && !found)
            {
                if (val < current.data)
                {
                    current = current.left;
                }
                else if (val > current.data)
                {
                    current = current.right;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        BinarySearchTree Insert(int val)
        {
            Node newNode = new Node(val);
            if (this.root == null)
            {
                this.root = newNode;
                return this;
            }
            else
            {
                Node currentNode = this.root;
                while (true)
                {
                    if (val < currentNode.data)
                    {
                        if (currentNode.left == null)
                        {
                            currentNode.left = newNode;
                            return this;
                        }
                        else
                        {
                            currentNode = currentNode.left;
                        }
                    }
                    else if (val > currentNode.data)
                    {
                        if (currentNode.right == null)
                        {
                            currentNode.right = newNode;
                            return this;
                        }
                        else
                        {
                            currentNode = currentNode.right;
                        }
                    }
                }
            }
        }

        List<int> BFS()
        {
            var queue = new List<Node>();
            var result = new List<int>();
            queue.Add(this.root);
            while (queue.Any())
            {
                result.Add(queue[0].data);
                if (queue[0].left != null) queue.Add(queue[0].left);
                if (queue[0].right != null) queue.Add(queue[0].right);
                queue.RemoveAt(0);
            }
            return result;
        }

        List<int> DFSPreOrder()
        {
            var result = new List<int>();
            void Traverse(Node node)
            {
                result.Add(node.data);
                if (node.left != null) Traverse(node.left);
                if (node.right != null) Traverse(node.right);
            }
            Traverse(this.root);
            return result;
        }
        List<int> DFSPostOrder()
        {
            var result = new List<int>();
            void Traverse(Node node)
            {
                if (node.left != null) Traverse(node.left);
                if (node.right != null) Traverse(node.right);
                result.Add(node.data);
            }
            Traverse(this.root);
            return result;
        }
        List<int> DFSInOrder()
        {
            var result = new List<int>();
            void Traverse(Node node)
            {
                if (node.left != null) Traverse(node.left);
                result.Add(node.data);
                if (node.right != null) Traverse(node.right);
            }
            Traverse(this.root);
            return result;
        }

        static Node MirrorImage(Node node)
        {
            if (node == null) return node;

            Node left = MirrorImage(node.left);
            Node right = MirrorImage(node.right);

            node.right = left;
            node.left = right;

            return node;
        }

        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            Console.WriteLine("New tree with 5, 10 ,15");
            tree.root = new Node(10);
            tree.root.right = new Node(15);
            tree.root.left = new Node(5);
            Console.WriteLine("Insert 1, 6, 16");
            tree.Insert(16);
            tree.Insert(1);
            tree.Insert(6);
            Console.WriteLine("BFS Traverse:");
            foreach (var x in (tree.BFS()))
            {
                Console.WriteLine(" | " + x);
            };
            Console.WriteLine("Find 10: " + tree.Find(10)); Console.WriteLine("Find 15: " + tree.Find(15));
            Console.WriteLine("Find -1: " + tree.Find(-1));
            var result = tree.DFSPreOrder();
            Console.WriteLine("DFS PreOrder: ");
            foreach (var x in result) Console.WriteLine(" | " + x);
            Console.WriteLine("DFS PostOrder: ");
            foreach (var x in (tree.DFSPostOrder())) Console.WriteLine(" | " + x);
            Console.WriteLine("DFS InOrder: ");
            foreach (var x in (tree.DFSInOrder())) Console.WriteLine(" | " + x);

            Node mirrorNode = MirrorImage(tree.root);
            tree.root = mirrorNode;
            Console.WriteLine("DFS Mirror Image InOrder: ");
            foreach (var x in (tree.DFSInOrder())) Console.WriteLine(" | " + x);
        }
    }
}
