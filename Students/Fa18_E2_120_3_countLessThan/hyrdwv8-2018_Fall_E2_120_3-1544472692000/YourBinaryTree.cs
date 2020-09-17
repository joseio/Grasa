

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

	private int count(BinaryTree.Node n, System.IComparable v)
	{
		if (n == null)
		{
			return 0;
		}
		else
		{
			int c = 0;
			if (n.value.CompareTo(v) > 0)
			{
				c++;
			}
			int l = count(n.left, v);
			int r = count(n.right, v);
			return c + l + r;
		}
	}
}