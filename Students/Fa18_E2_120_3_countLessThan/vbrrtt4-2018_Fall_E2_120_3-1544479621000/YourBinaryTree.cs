

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return h(value, root);
	}

	private int h(System.IComparable value, BinaryTree.Node n)
	{
		if (n == null)
		{
			return 0;
		}
		if (value.CompareTo(n.value) < 0)
		{
			return 1 + h(value, n.left) + h(value, n.right);
		}
		return h(value, n.left) + h(value, n.right);
	}
}