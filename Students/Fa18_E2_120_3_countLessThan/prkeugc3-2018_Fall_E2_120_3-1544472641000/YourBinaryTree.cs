

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		else
		{
			return countLessThan(value, root);
		}
	}

	protected internal virtual int countLessThan(System.IComparable val, BinaryTree.Node
		 node)
	{
		if (node == null)
		{
			return 0;
		}
		else if (node.value.CompareTo(val) >= 0)
		{
			return 1 + countLessThan(val, node.right) + countLessThan(val, node.left);
		}
		else
		{
			return countLessThan(val, node.right) + countLessThan(val, node.left);
		}
	}
}