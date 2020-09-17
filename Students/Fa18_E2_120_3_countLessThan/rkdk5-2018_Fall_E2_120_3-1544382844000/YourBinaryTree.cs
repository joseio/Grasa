

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

	private int clt(BinaryTree.Node cur, System.IComparable value)
	{
		if (cur == null)
		{
			return 0;
		}
		int cnt = 0;
		if (cur.value.CompareTo(value) > 0)
		{
			cnt = 1;
		}
		return cnt + clt(cur.right, value) + clt(cur.left, value);
	}
}