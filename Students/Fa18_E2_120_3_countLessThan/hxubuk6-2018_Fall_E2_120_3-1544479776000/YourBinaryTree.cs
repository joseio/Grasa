

public class YourBinaryTree : BinaryTree
{
	/// <exception cref="System.ArgumentException"/>
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		else
		{
			return helper(value, root);
		}
	}

	private int helper(System.IComparable value, BinaryTree.Node current)
	{
		if (current == null)
		{
			return 0;
		}
		else if (current.value.CompareTo(value) > 0)
		{
			return helper(value, current.right) + helper(value, current.left) + 1;
		}
		else
		{
			return helper(value, current.right) + helper(value, current.left);
		}
	}
}