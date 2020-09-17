

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		return countLessThan(root, value);
	}

	private int countLessThan(BinaryTree.Node current, System.IComparable value)
	{
		int count = 0;
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		if (current == null)
		{
			return 0;
		}
		if (current != null && current.value.CompareTo(value) > 0)
		{
			count += 1;
		}
		return count + countLessThan(current.right, value) + countLessThan(current.left, 
			value);
	}
}