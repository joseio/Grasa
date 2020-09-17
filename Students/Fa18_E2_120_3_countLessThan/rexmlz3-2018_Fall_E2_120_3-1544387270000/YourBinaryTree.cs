

public class YourBinaryTree : BinaryTree
{
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
		return countLessThan(root, value);
	}

	private int countLessThan(BinaryTree.Node cur, System.IComparable value)
	{
		if (cur == null)
		{
			return 0;
		}
		int tmp = 0;
		if (value.CompareTo(cur.value) < 0)
		{
			tmp = 1;
		}
		return tmp + countLessThan(cur.left, value) + countLessThan(cur.right, value);
	}
}