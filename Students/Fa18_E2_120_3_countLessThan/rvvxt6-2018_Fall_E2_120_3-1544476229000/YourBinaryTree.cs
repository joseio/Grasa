

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

	private int countLessThan(System.IComparable value, BinaryTree.Node current)
	{
		if (value == null || current == null)
		{
			return 0;
		}
		int count = 0;
		if (value.CompareTo(current.value) < 0)
		{
			count = 1;
		}
		return count + countLessThan(value, current.left) + countLessThan(value, current.
			right);
	}
}