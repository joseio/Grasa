

public class YourBinaryTree : BinaryTree
{
	/// <exception cref="System.ArgumentException"/>
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		else
		{
			return count(root, value);
		}
	}

	private int count(BinaryTree.Node current, System.IComparable value)
	{
		if (current == null)
		{
			return 0;
		}
		else if (current.value.CompareTo(value) > 0)
		{
			return 1 + count(current.right, value) + count(current.left, value);
		}
		else
		{
			return count(current.right, value) + count(current.left, value);
		}
	}
}