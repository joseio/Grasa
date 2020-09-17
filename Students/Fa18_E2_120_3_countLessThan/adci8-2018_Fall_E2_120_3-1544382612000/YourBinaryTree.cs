

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
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