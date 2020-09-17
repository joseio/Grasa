

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

	private int countLessThan(System.IComparable v, BinaryTree.Node current)
	{
		if (current == null)
		{
			return 0;
		}
		if (current.value.CompareTo(v) > 0)
		{
			return 1 + countLessThan(v, current.right) + countLessThan(v, current.left);
		}
		return countLessThan(v, current.right) + countLessThan(v, current.left);
	}
}