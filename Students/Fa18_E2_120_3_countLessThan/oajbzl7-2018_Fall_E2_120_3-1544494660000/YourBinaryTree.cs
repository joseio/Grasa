

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		int count = 0;
		return helper(root, value, count);
	}

	public virtual int helper(BinaryTree.Node current, System.IComparable value, int 
		count)
	{
		if (current == null)
		{
			return 0;
		}
		if (current.value.CompareTo(value) > 0)
		{
			return helper(current.right, value, count) + helper(current.left, value, count) +
				 1;
		}
		return helper(current.right, value, count) + helper(current.left, value, count);
	}
}