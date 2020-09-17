

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

	private int countLessThan(BinaryTree.Node current, System.IComparable value)
	{
		if (current == null)
		{
			return 0;
		}
		int ct = 0;
		if (current.value.CompareTo(value) > 0)
		{
			ct = 1;
		}
		return ct + countLessThan(current.right, value) + countLessThan(current.left, value
			);
	}
}