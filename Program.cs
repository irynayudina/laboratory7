using System;
using System.Collections.Generic;

namespace laboratory7
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node()
        {

        }
        public Node(int data)
        {
            this.Data = data;

        }
        public override string ToString()
        {
            return $"Data: {Data}";
        }
        public override bool Equals(object obj)
        {
            Node oj = obj as Node;
            if(oj != null && oj.Data == this.Data)
            {
                if(oj.Left == null && this.Left == null && oj.Right == null && this.Right == null)
                {
                    return true;
                }
                if (oj.Left == null && this.Left == null)
                {
                    if (oj.Right != null && this.Right != null)
                    {
                        if (oj.Right.Data == this.Right.Data)
                        {
                            return true;
                        }
                    }
                }
                if(oj.Right == null && this.Right == null)
                {
                    if(oj.Left != null && this.Left != null)
                    {
                        if(oj.Left.Data == this.Left.Data)
                        {
                            return true;
                        }
                    }
                }
                if (oj.Left != null && this.Left != null && oj.Right != null && this.Right != null)
                {
                    if(oj.Left.Data == this.Left.Data && oj.Right.Data == this.Right.Data)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Node n1, Node n2)
        {
            if (object.ReferenceEquals(n1, null))
            {
                return object.ReferenceEquals(n2, null);
            }
            return n1.Equals(n2);
        }
        public static bool operator !=(Node n1, Node n2)
        {
            if (object.ReferenceEquals(n1, null))
            {
                return !object.ReferenceEquals(n2, null);
            }
            return !n1.Equals(n2);
        }
    }
    public class BinaryTree
    {
        private Node _root;
        public BinaryTree()
        {
            _root = null;
        }        
         ////////////////////////////////////////////////////////////////////////////////////////////////////INSERT////////////////////////////     
        public void Insert(int data)
        {
            // 1. If the tree is empty, return a new, single node 
            if (_root == null)
            {
                _root = new Node(data);
                return;
            }
            // 2. Otherwise, recur down the tree 
            InsertRec(_root, new Node(data));
        }
        private void InsertRec(Node root, Node newNode)
        {
            if (root == null)
                root = newNode;

            if (newNode.Data < root.Data)
            {
                if (root.Left == null)
                    root.Left = newNode;
                else
                    InsertRec(root.Left, newNode);
            }
            else
            {
                if (root.Right == null)
                    root.Right = newNode;
                else
                    InsertRec(root.Right, newNode);
            }
        }        
        ////////////////////////////////////////////////////////////////////////////////////////////////////////REMOVE//////////////////////
        public void Remove(int value)
        {
            this._root = Remove(this._root, value);
        }
        private Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) parent.Left = Remove(parent.Left, key);
            else if (key > parent.Data)
                parent.Right = Remove(parent.Right, key);
            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.Left == null)
                    return parent.Right;
                else if (parent.Right == null)
                    return parent.Left;
                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = MinValue(parent.Right);
                // Delete the inorder successor  
                parent.Right = Remove(parent.Right, parent.Data);
            }
            return parent;
        }
        private int MinValue(Node node)
        {
            int minv = node.Data;
            while (node.Left != null)
            {
                minv = node.Left.Data;
                node = node.Left;
            }
            return minv;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////PRINT//////////////////////
        public Node Root { get { return _root; } }
        public void Print()
        {
            Root.Print();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////FIND BY KEY STRAIGHT preORDER//////
        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.Left);
                TraversePreOrder(parent.Right);
            }
            Console.WriteLine();
        }
        public Node FindPreOrder(Node parent, int key)
        {
            findPreOrder(parent, key);
            if (Parent == null)
            {
                Console.WriteLine("Node is not found");
            }
            return Parent;
        }
        public Node Parent = null;
        private Node findPreOrder(Node parent, int key)
        {
            if (parent != null)
            {
                if(parent.Data == key)
                {
                    Parent = parent;
                    return parent;
                }
                else
                {
                    findPreOrder(parent.Left, key);
                    findPreOrder(parent.Right, key);
                }
                return parent;
            }
            else
            {
                return null;
            }
            
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////FIND BY KEY BACKWARDS postORDER/////
        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.Left);
                TraversePostOrder(parent.Right);
                Console.Write(parent.Data + " ");
            }
            Console.WriteLine();
        }
        public Node FindPostOrder(Node parent, int key)
        {
            findPostOrder(parent, key);
            if (Parent == null)
            {
                Console.WriteLine("Node is not found");
            }
            return Parent;
        }
        private Node findPostOrder(Node parent, int key)
        {
            if (parent != null)
            {
                findPostOrder(parent.Left, key);
                findPostOrder(parent.Right, key);
                if (parent.Data == key)
                {
                    Parent = parent;
                    return parent;
                }
            }
            return null;
        }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////FIND MIN//////////////////////
    public Node FindMin()
        {
            return Min(_root);
        }
        private Node Min(Node node)
        {
            int minv;
            if (node != null)
            {
                minv = node.Data;

                while (node.Left != null)
                {
                    minv = node.Left.Data;
                    node = node.Left;
                }
            }
            return node;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////FIND MAX///////////////////////
        public Node FindMax()
        {
            return Max(_root);
        }
        private Node Max(Node node)
        {
            int minv;
            if (node != null)
            {
                minv = node.Data;

                while (node.Right != null)
                {
                    minv = node.Right.Data;
                    node = node.Right;
                }
            }
            return node;
        }
        //////////////////////////////////////////////////////////////////GET LEVEL OF NODE////////////////////////////////////////
        private int getLevelUtil(Node root, Node searched, int level)
        {
            if (root == null)
            {
                return 0;
            }

            if (root == searched)
            {
                return level;
            }

            int downlevel = getLevelUtil(root.Left, searched, level + 1);
            if (downlevel != 0)
            {
                return downlevel;
            }

            downlevel = getLevelUtil(root.Right, searched, level + 1);
            return downlevel;
        }
        public int getLevel(Node node, Node searched)
        {
            return getLevelUtil(node, searched, 1);
        }
    }
    public static class BTreePrinter
    {
        class NodeInfo
        {
            public Node NODE;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }

        public static void Print(this Node root, string textFormat = "0", int spacing = 1, int topMargin = 2, int leftMargin = 2)
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { NODE = next, Text = next.Data.ToString(textFormat) };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.NODE.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    int top = rootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);
                    if (item.Left != null)
                    {
                        Print("/", top + 1, item.Left.EndPos);
                        Print("_", top, item.Left.EndPos + 1, item.StartPos);
                    }
                    if (item.Right != null)
                    {
                        Print("_", top, item.EndPos, item.Right.StartPos - 1);
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.NODE.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos - 1;
                        else
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private static void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            string line;
            int a = 0, b = 0;
            while (a != 10)
            {
                Console.WriteLine("choose action: \n1-add\n2-print\n3-remove\n4-traverse prefix\n5-find prefix\n6-traverse postfix\n7-find postfix\n8-find min\n9-find max\n10-exit");
                line = Console.ReadLine();
                a = int.Parse(line);
                switch (a)
                {
                    case 1:
                        Console.WriteLine("enter value: ");
                        line = Console.ReadLine();
                        b = int.Parse(line);
                        tree.Insert(b);
                        break;
                    case 2:
                        tree.Root.Print();
                        break;
                    case 3:
                        Console.WriteLine("enter value: ");
                        line = Console.ReadLine();
                        b = int.Parse(line);
                        tree.Remove(b);
                        break;
                    case 4:
                        tree.TraversePreOrder(tree.Root);
                        break;
                    case 5:
                        Console.WriteLine("enter value: ");
                        line = Console.ReadLine();
                        b = int.Parse(line);
                        Node n = tree.FindPreOrder(tree.Root, b);
                        Console.WriteLine(n + $" Level: {tree.getLevel(tree.Root, n)}");
                        break;
                    case 6:
                        tree.TraversePostOrder(tree.Root);
                        break;
                    case 7:
                        Console.WriteLine("enter value: ");
                        line = Console.ReadLine();
                        b = int.Parse(line);
                        Node n1 = tree.FindPostOrder(tree.Root, b);
                        Console.WriteLine(n1 + $" Level: {tree.getLevel(tree.Root, n1)}");
                        break;
                    case 8:
                        Console.WriteLine(tree.FindMin());
                        break;
                    case 9:
                        Console.WriteLine(tree.FindMax());
                        break;
                }
            }
        }
    }
}
