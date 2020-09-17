

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return helper(value, root);
	}

	private int helper(System.IComparable value, BinaryTree.Node current)
	{
		if (current == null)
		{
			return 0;
		}
		int count = 0;
		if (current.value.CompareTo(value) > 0)
		{
			count++;
		}
		return count + helper(value, current.left) + helper(value, current.right);
	}
}