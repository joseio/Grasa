

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

	private int helper(BinaryTree.Node current, System.IComparable val)
	{
		if (current == null)
		{
			return 0;
		}
		if (current.value.CompareTo(val) > 0)
		{
			return helper(current.left, val) + helper(current.right, val) + 1;
		}
		return helper(current.left, val) + helper(current.right, val);
	}
}