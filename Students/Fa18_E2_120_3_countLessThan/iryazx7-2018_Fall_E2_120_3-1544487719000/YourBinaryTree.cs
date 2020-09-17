

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		return func(root, value);
	}

	public virtual int func(BinaryTree.Node current, System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		if (current == null)
		{
			return 0;
		}
		int x;
		if (value.CompareTo(current.value) < 0)
		{
			x = 1;
		}
		else
		{
			x = 0;
		}
		return x + func(current.left, value) + func(current.right, value);
	}
}