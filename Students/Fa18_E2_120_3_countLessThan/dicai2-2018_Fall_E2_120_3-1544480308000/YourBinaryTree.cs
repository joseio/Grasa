

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return cL(root, value);
	}

	private int cL(BinaryTree.Node current, System.IComparable val)
	{
		if (current == null)
		{
			return 0;
		}
		int count = 0;
		if (current.value.CompareTo(val) > 0)
		{
			count++;
		}
		return count + cL(current.left, val) + cL(current.right, val);
	}
}