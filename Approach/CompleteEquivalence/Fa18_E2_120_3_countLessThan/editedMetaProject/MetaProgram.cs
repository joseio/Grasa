using System.Text.RegularExpressions;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using System.Diagnostics;

namespace MetaProject {
    [PexClass(typeof(MetaProgram))]
    public partial class MetaProgram {

        //SubmissionA's base class goes here that the sutdent's solution requires
        public class BinaryTree
        {
            private static Random random = new Random();

            protected internal class Node
            {
                private readonly BinaryTree outerInstance;

                protected internal IComparable value;
                protected internal Node right;
                protected internal Node left;
                internal Node(BinaryTree outerInstance, IComparable setValue)
                {
                    this.outerInstance = outerInstance;
                    value = setValue;
                }
            }

            protected internal Node root;
            public void add(IComparable value)
            {
                add(root, value);
            }
            private void add(Node current, IComparable value)
            {
                if (current == null)
                {
                    root = new Node(this, value);
                }
                else if (current.right == null)
                {
                    current.right = new Node(this, value);
                }
                else if (current.left == null)
                {
                    current.left = new Node(this, value);
                }
                else if (random.Next(2) == 0)
                {
                    add(current.right, value);
                }
                else
                {
                    add(current.left, value);
                }
            }

            protected internal virtual int countLessThan(IComparable value)
            {
                return 0;
            }
        }






        [PexMethod]
        public static void Check([PexAssumeNotNull] int[] inputArr, int x)
        {
            // I think this is where you compare the student's solution to the actual solution
        }

        public static bool isEqual(dynamic current, dynamic other){
            if(current == null && other == null)
                return true;

            //Ensure current is valid Node type
            if (!(current is BinaryTree.Node || current is BinaryTreeSolution.Node
                || current is BinaryTreeSolutionForReal.Node))
                return false;
            //Ensure other is valid Node type
            if (!(other is BinaryTree.Node || other is BinaryTreeSolution.Node
                || other is BinaryTreeSolutionForReal.Node))
                return false;

            if(!current.value.Equals(other.value))
                return false;
            else 
            {
                return current.value.Equals(other.value) && isEqual(current.left, other.left) 
                && isEqual(current.right, other.right);
            }
        }

        //Initial input argument = root
        public dynamic Clone(dynamic inputTree, dynamic current)
        {
            if (current == null)
                return null;  

            //temp is BinaryTree whose type is determined during runtime
            Type type = inputTree.GetType();
            dynamic temp = Activator.CreateInstance(type);
            
            //Ensure current is valid Node type
            if (!(current is BinaryTree.Node || current is BinaryTreeSolution.Node 
                || current is BinaryTreeSolutionForReal.Node))
                return null;

            temp.value = current.value;
            if(current.left != null)
            {
                 temp.left = Clone(inputTree, current.left);
            }
            if(current.right != null)
            {
                 temp.right = Clone(inputTree, current.left);
            }
            return temp;
        }

        public int Count(dynamic current)
        {
            if(current == null)
                return 0;
            
            //Ensure current is valid Node type
            if (!(current is BinaryTree.Node || current is BinaryTreeSolution.Node
                || current is BinaryTreeSolutionForReal.Node))
                return 0;

            int lCount = 0;
            int rCount = 0;
            if (current.left != null) {
                lCount += Count(current.left);
            }
            if (current.right != null) {
             rCount += Count(current.right);
            }
            return 1 + lCount + rCount;
        }

        public static bool isNull(Object b)
        {
            return b == null;
        }
    }




    //SubmissionB
    public class BinaryTreeSolution {
        public BinaryTreeSolution() { }

        private static Random random = new Random();

        protected internal class Node
        {
            private readonly BinaryTreeSolution outerInstance;

            protected internal IComparable value;
            protected internal Node right;
            protected internal Node left;
            internal Node(BinaryTreeSolution outerInstance, IComparable setValue)
            {
                this.outerInstance = outerInstance;
                value = setValue;
            }
        }

        protected internal Node root;
        public void add(IComparable value)
        {
            add(root, value);
        }
        private void add(Node current, IComparable value)
        {
            if (current == null)
            {
                root = new Node(this, value);
            }
            else if (current.right == null)
            {
                current.right = new Node(this, value);
            }
            else if (current.left == null)
            {
                current.left = new Node(this, value);
            }
            else if (random.Next(2) == 0)
            {
                add(current.right, value);
            }
            else
            {
                add(current.left, value);
            }
        }

        protected internal virtual int countLessThan(IComparable value)
        {
            return 0;
        }
    }






    //"Instructor's" Solution
    public class BinaryTreeSolutionForReal {
        public BinaryTreeSolutionForReal() { }

        private static Random random = new Random();

        protected internal class Node
        {
            private readonly BinaryTreeSolutionForReal outerInstance;

            protected internal IComparable value;
            protected internal Node right;
            protected internal Node left;
            internal Node(BinaryTreeSolutionForReal outerInstance, IComparable setValue)
            {
                this.outerInstance = outerInstance;
                value = setValue;
            }
        }

        protected internal Node root;
        public void add(IComparable value)
        {
            add(root, value);
        }
        private void add(Node current, IComparable value)
        {
            if (current == null)
            {
                root = new Node(this, value);
            }
            else if (current.right == null)
            {
                current.right = new Node(this, value);
            }
            else if (current.left == null)
            {
                current.left = new Node(this, value);
            }
            else if (random.Next(2) == 0)
            {
                add(current.right, value);
            }
            else
            {
                add(current.left, value);
            }
        }

        protected internal virtual int countLessThan(IComparable value)
        {
            return countLessThan(root, value);
        }
        private int countLessThan(Node current, IComparable value)
        {
            if (current == null)
            {
                return 0;
            }
            int count = 0;
            if (value.CompareTo(current.value) < 0)
            {
                count = 1;
            }
            return count + countLessThan(current.left, value) + countLessThan(current.right, value);
        }
    }
}
