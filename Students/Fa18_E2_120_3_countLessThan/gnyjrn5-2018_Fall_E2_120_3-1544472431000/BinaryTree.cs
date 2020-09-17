

public class BinaryTree
{
	private static Random random = new Random();

	protected internal class Node
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

	protected internal virtual int countLessThan(System.IComparable value)
	{
		return 0;
	}
}