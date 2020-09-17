

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable val)
	{
		if (val == null)
		{
			throw new System.ArgumentException();
		}
		return clt(root, val);
	}

	private int clt(BinaryTree.Node current, System.IComparable val)
	{
		if (current == null)
		{
			return 0;
		}
		int ret = 0;
		if (val.CompareTo(current.value) < 0)
		{
			ret++;
		}
		return ret + clt(current.left, val) + clt(current.right, val);
	}
}