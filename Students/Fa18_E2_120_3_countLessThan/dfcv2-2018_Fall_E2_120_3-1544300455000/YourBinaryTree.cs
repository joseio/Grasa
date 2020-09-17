

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return count(root, value);
	}

	public virtual int count(BinaryTree.Node c, System.IComparable v)
	{
		if (c == null)
		{
			return 0;
		}
		if (c.value.CompareTo(v) > 0)
		{
			return 1 + count(c.right, v) + count(c.left, v);
		}
		else
		{
			return count(c.right, v) + count(c.left, v);
		}
	}
}