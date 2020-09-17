

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException("argument cannot be null");
		}
		return countLessThan(value, root);
	}

	private int countLessThan(System.IComparable value, BinaryTree.Node current)
	{
		if (current == null)
		{
			return 0;
		}
		int count = 0;
		if (current.value.CompareTo(value) > 0)
		{
			count = 1;
		}
		return count + countLessThan(value, current.right) + countLessThan(value, current
			.left);
	}
}