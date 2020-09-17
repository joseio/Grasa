

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return countLessThan(value, 0, root);
	}

	private int countLessThan(System.IComparable value, int count, BinaryTree.Node current
		)
	{
		if (current == null)
		{
			return count;
		}
		if (value.CompareTo(current.value) < 0)
		{
			count++;
		}
		return count + countLessThan(value, 0, current.left) + countLessThan(value, 0, current
			.right);
	}
}