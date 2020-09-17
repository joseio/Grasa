

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw (new System.ArgumentException());
		}
		return countLessThan(root, value);
	}

	protected internal virtual int countLessThan(BinaryTree.Node current, System.IComparable
		 value)
	{
		if (current == null)
		{
			return 0;
		}
		int num = 0;
		if (value.CompareTo(current.value) < 0)
		{
			num++;
		}
		if (current.right != null)
		{
			num = num + countLessThan(current.right, value);
		}
		if (current.left != null)
		{
			num = num + countLessThan(current.left, value);
		}
		return num;
	}
}