

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return a(value, root);
	}

	public virtual int a(System.IComparable value, BinaryTree.Node current)
	{
		int count = 0;
		if (current == null)
		{
			return 0;
		}
		if (current.value.CompareTo(value) > 0)
		{
			count = 1;
		}
		return count + a(value, current.left) + a(value, current.right);
	}
}