

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

	public virtual int count(BinaryTree.Node curr, System.IComparable value)
	{
		if (curr == null)
		{
			return 0;
		}
		if (curr.value.CompareTo(value) > 0)
		{
			return 1 + count(curr.left, value) + count(curr.right, value);
		}
		return 0 + count(curr.left, value) + count(curr.right, value);
	}
}