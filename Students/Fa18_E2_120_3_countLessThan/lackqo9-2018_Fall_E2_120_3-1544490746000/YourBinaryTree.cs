

public class YourBinaryTree : BinaryTree
{
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
		if (value.CompareTo(current.value) < 0)
		{
			return 1 + countLessThan(current.left, value) + countLessThan(current.right, value
				);
		}
		else
		{
			return countLessThan(current.left, value) + countLessThan(current.right, value);
		}
	}
}