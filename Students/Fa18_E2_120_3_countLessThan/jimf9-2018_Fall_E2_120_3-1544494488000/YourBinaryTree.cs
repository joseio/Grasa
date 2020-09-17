

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		return countLessThan(root, value);
	}

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
		if (current.right == null && current.left == null)
		{
			if (current.value.CompareTo(value) > 0)
			{
				return 1;
			}
			else
			{
				return 0;
			}
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