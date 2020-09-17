

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
		int count = 0;
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		if (current == null)
		{
			return 0;
		}
		if (value.CompareTo(current.value) < 0)
		{
			count++;
		}
		return helper(value, current.left) + helper(value, current.right) + count;
	}
}