

public class YourBinaryTree : BinaryTree
{
	/// <exception cref="System.ArgumentException"/>
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return countLessThan(root, value);
	}

	private int countLessThan(BinaryTree.Node c, System.IComparable value)
	{
		if (c == null)
		{
			return 0;
		}
		int count = 0;
		if (c.value.CompareTo(value) > 0)
		{
			count = 1;
		}
		return count + countLessThan(c.left, value) + countLessThan(c.right, value);
	}
}