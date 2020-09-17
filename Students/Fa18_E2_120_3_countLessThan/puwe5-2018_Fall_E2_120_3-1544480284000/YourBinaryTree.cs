

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		return countLessThan(value, root);
	}

	private int countLessThan(System.IComparable value, BinaryTree.Node current)
	{
		int count = 0;
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		if (current == null)
		{
			return 0;
		}
		if (current.value.CompareTo(value) > 0)
		{
			count = 1;
		}
		return count + countLessThan(value, current.left) + countLessThan(value, current.
			right);
	}
}