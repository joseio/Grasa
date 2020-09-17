

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

	public virtual int less(BinaryTree.Node current, System.IComparable a)
	{
		if (current == null)
		{
			return 0;
		}
		if (current.value.CompareTo(a) > 0)
		{
			return 1 + less(current.left, a) + less(current.right, a);
		}
		else
		{
			return less(current.left, a) + less(current.right, a);
		}
	}
}