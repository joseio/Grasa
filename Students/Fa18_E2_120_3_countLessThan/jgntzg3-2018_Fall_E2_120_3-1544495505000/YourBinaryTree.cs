

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return clt(root, value);
	}

	private int clt(BinaryTree.Node c, System.IComparable value)
	{
		int count = 0;
		if (c == null)
		{
			return 0;
		}
		if (c.value.CompareTo(value) > 0)
		{
			count = 1;
		}
		return count + clt(c.left, value) + clt(c.right, value);
	}
}