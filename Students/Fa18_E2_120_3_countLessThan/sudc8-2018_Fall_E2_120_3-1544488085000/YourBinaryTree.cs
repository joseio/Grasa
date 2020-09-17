

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

	/// <exception cref="System.ArgumentException"/>
	private int countLessThan(BinaryTree.Node current, System.IComparable value)
	{
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
			return 1 + countLessThan(current.right, value) + countLessThan(current.left, value
				);
		}
		else
		{
			return countLessThan(current.right, value) + countLessThan(current.left, value);
		}
	}
}