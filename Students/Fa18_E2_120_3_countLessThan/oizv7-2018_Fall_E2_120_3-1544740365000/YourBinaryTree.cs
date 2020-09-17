

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return countLessThan(value, root);
	}

	protected internal virtual int countLessThan(System.IComparable value, BinaryTree.Node
		 current)
	{
		if (current == null)
		{
			return 0;
		}
		int c = 0;
		if (value.CompareTo(current.value) < 0)
		{
			c = 1;
		}
		return c + countLessThan(value, current.left) + countLessThan(value, current.right
			);
	}
}