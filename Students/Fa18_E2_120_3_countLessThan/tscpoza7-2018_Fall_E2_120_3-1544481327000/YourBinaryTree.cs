

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		return countLess(root, value);
	}

	private int countLess(BinaryTree.Node current, System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		if (current == null)
		{
			return 0;
		}
		else if (current.left == null && current.right == null)
		{
			if (current.value.CompareTo(value) > 0)
			{
				return 1;
			}
		}
		if (current.value.CompareTo(value) > 0)
		{
			return 1 + countLess(current.left, value) + countLess(current.right, value);
		}
		else
		{
			return countLess(current.left, value) + countLess(current.right, value);
		}
	}
}