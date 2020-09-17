using System.Text.RegularExpressions;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using System.Diagnostics;
namespace MetaProject
{
    [PexClass(typeof(MetaProgram))]
    public partial class MetaProgram
    {
        //SubmissionA's base class goes here that the sutdent's solution requires
        public class BinaryTree
{
	private static Random random = new Random();
	public  class Node           ///////////<-----------------05/04/19, changed from 'protected internal class Node' to 'public class Node'
	{
		protected internal System.IComparable value;
		protected internal BinaryTree.Node right;
		protected internal BinaryTree.Node left;
		internal Node(BinaryTree _enclosing, System.IComparable setValue)
		{
			this._enclosing = _enclosing;
			this.value = setValue;
		}
		private readonly BinaryTree _enclosing;
	}
	protected internal BinaryTree.Node root;
	public void add(System.IComparable value)
	{
		add(root, value);
	}
	private void add(BinaryTree.Node current, System.IComparable value)
	{
		if (current == null)
		{
			root = new BinaryTree.Node(this, value);
		}
		else if (current.right == null)
		{
			current.right = new BinaryTree.Node(this, value);
		}
		else if (current.left == null)
		{
			current.left = new BinaryTree.Node(this, value);
		}
		else if (random.Next(2)==0)
		{
			add(current.right, value);
		}
		else
		{
			add(current.left, value);
		}
	}
	protected internal  int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException("This is bogus");
		}
		return countHelp(root, value);
	}
	private int countHelp(BinaryTree.Node current, System.IComparable value)
	{
		if (current == null)
		{
			return 0;
		}
		if (current.value.CompareTo(value) > 0)
		{
			return 1 + countHelp(current.left, value) + countHelp(current.right, value);
		}
		return countHelp(current.left, value) + countHelp(current.right, value);
	}
}
	
        [PexMethod]
        public static void Check([PexAssumeUnderTest] BinaryTree tree1, [PexAssumeUnderTest] BinaryTreeSolution tree2, double x, string inputString, bool treeType, int numIterations)
        {
            //Assume both trees have same contents
            PexAssume.IsTrue(isEqual(tree1.root, tree2.root));
            //Assume both trees have same number of nodes
            PexAssume.IsTrue(Count(tree1.root).Equals(Count(tree2.root)));
            //Assume trees don't point to same mem locations
            PexAssume.AreNotSame(tree1, tree2);

            bool tree1Exception = false;
            bool tree2Exception = false;

            try
            {
                if (treeType)
                    for (int i = 0; i < numIterations; i++)
                        tree1.add(inputString); //treeType = true => input string 
                else
                    for (int i = 0; i < numIterations; i++ )
                        tree1.add(x); //treeType = false => input double
            }
            catch (Exception)
            {
                tree1Exception = true;
            }
            try
            {
                if (treeType)
                    for (int i = 0; i < numIterations; i++)
                        tree2.add(inputString);
                else
                    for (int i = 0; i < numIterations; i++)
                        tree2.add(x);
            }
            catch (Exception)
            {
                tree2Exception = true;
            }

            bool passingCondition = ((tree1Exception == tree2Exception && tree1Exception == true) 
                || (tree1Exception == tree2Exception && tree1Exception == false 
                && tree1.countLessThan(x).Equals(tree2.countLessThan(x))));
            bool failingCondition = !passingCondition;
            if (failingCondition)
                throw new Exception();
        }


        public static bool isEqual(dynamic current, dynamic other)
        {
            if (current == null && other == null)
                return true;
            //Ensure current is valid Node type
            if (!(current is BinaryTree.Node || current is BinaryTreeSolution.Node
                || current is BinaryTreeSolutionForReal.Node))
                return false;
            //Ensure other is valid Node type
            if (!(other is BinaryTree.Node || other is BinaryTreeSolution.Node
                || other is BinaryTreeSolutionForReal.Node))
                return false;
            if (!current.value.Equals(other.value))
                return false;
            else
            {
                return current.value.Equals(other.value) && isEqual(current.left, other.left)
                && isEqual(current.right, other.right);
            }
        }
        //Initial input argument = root
        public static dynamic Clone(dynamic inputTree, dynamic current)
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
            if (current.left != null)
            {
                temp.left = Clone(inputTree, current.left);
            }
            if (current.right != null)
            {
                temp.right = Clone(inputTree, current.left);
            }
            return temp;
        }
        public static int Count(dynamic current)
        {
            if (current == null)
                return 0;
            //Ensure current is valid Node type
            if (!(current is BinaryTree.Node || current is BinaryTreeSolution.Node
                || current is BinaryTreeSolutionForReal.Node))
                return 0;
            int lCount = 0;
            int rCount = 0;
            if (current.left != null)
            {
                lCount += Count(current.left);
            }
            if (current.right != null)
            {
                rCount += Count(current.right);
            }
            return 1 + lCount + rCount;
        }
    }
    //SubmissionB
    public class BinaryTreeSolution
    {
        public BinaryTreeSolution() { }
        private static Random random = new Random();
        public class Node
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
    public class BinaryTreeSolutionForReal
    {
        public BinaryTreeSolutionForReal() { }
        private static Random random = new Random();
        public class Node
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
