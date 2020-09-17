

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
		if ((current.value).CompareTo(value) > 0)
		{
			return 1 + countLessThan(value, current.right) + countLessThan(value, current.left
				);
		}
		else
		{
			return 0 + countLessThan(value, current.right) + countLessThan(value, current.left
				);
		}
	}
}