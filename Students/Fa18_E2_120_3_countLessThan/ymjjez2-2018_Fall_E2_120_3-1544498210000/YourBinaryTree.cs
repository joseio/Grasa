

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
		if (current.value.CompareTo(value) > 0)
		{
			return (1 + helper(current.left, value) + helper(current.right, value));
		}
		else
		{
			return (helper(current.left, value) + helper(current.right, value));
		}
	}
}