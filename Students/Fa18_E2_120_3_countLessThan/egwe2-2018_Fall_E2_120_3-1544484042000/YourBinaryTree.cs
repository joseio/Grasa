

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return less(root, value);
	}

	private int less(BinaryTree.Node current, System.IComparable val)
	{
		if (current == null)
		{
			return 0;
		}
		if ((current.value).CompareTo(val) > 0)
		{
			return 1 + less(current.left, val) + less(current.right, val);
		}
		return less(current.left, val) + less(current.right, val);
	}
}