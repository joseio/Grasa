

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return helper(root, value);
	}

	private int helper(BinaryTree.Node current, System.IComparable value)
	{
		if (current == null)
		{
			return 0;
		}
		int toAdd = 0;
		if (value.CompareTo(current.value) < 0)
		{
			toAdd = 1;
		}
		return toAdd + helper(current.left, value) + helper(current.right, value);
	}
}