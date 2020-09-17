

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
		int count = 0;
		if (value.CompareTo(current.value) < 0)
		{
			count = 1;
		}
		return count + countLessThan(current.right, value) + countLessThan(current.left, 
			value);
	}
}