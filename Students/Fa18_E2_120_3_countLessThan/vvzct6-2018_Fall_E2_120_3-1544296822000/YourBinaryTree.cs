

public class YourBinaryTree : BinaryTree
{
	/// <exception cref="System.ArgumentException"/>
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
		int n = 0;
		if (root.value.CompareTo(value) > 0)
		{
			n = 1;
		}
		return n + countLessThan(value, root.left) + countLessThan(value, root.right);
	}

	protected internal virtual int countLessThan(System.IComparable val, BinaryTree.Node
		 n)
	{
		if (n == null)
		{
			return 0;
		}
		int nu = 0;
		if (n.value.CompareTo(val) > 0)
		{
			nu = 1;
		}
		return nu + countLessThan(val, n.left) + countLessThan(val, n.right);
	}
}