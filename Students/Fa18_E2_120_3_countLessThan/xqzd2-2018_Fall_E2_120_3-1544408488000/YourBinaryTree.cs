

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			System.ArgumentException e = new System.ArgumentException();
			throw e;
		}
		return countLessThan(value, root);
	}

	private int countLessThan(System.IComparable a, BinaryTree.Node current)
	{
		if (current == null)
		{
			return 0;
		}
		if (current.value.CompareTo(a) <= 0)
		{
			return (countLessThan(a, current.left) + countLessThan(a, current.right));
		}
		return countLessThan(a, current.left) + countLessThan(a, current.right) + 1;
	}
}