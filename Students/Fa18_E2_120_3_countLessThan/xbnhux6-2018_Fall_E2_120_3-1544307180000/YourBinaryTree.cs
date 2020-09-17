

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		if (root == null)
		{
			return 0;
		}
		return recur(root, value);
	}

	private int recur(BinaryTree.Node current, System.IComparable value)
	{
		if (current == null)
		{
			return 0;
		}
		if (current.value.CompareTo(value) > 0)
		{
			return 1 + recur(current.right, value) + recur(current.left, value);
		}
		else
		{
			return recur(current.right, value) + recur(current.left, value);
		}
	}
}