

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
			return countLessThan(root, value);
		}
	}

	private int countLessThan(BinaryTree.Node current, System.IComparable value)
	{
		if (current == null)
		{
			return 0;
		}
		else if (current.value.CompareTo(value) > 0)
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