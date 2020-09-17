

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
		if (current == null)
		{
			return 0;
		}
		if (value.CompareTo(current.value) < 0)
		{
			return 1 + countLessThan(value, current.left) + countLessThan(value, current.right
				);
		}
		return countLessThan(value, current.left) + countLessThan(value, current.right);
	}
}