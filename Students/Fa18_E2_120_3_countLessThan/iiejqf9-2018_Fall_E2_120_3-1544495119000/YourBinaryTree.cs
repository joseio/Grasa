

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException("Hi Geofffff");
		}
		return countLessThan(root, value);
	}

	protected internal virtual int countLessThan(BinaryTree.Node current, System.IComparable
		 hi)
	{
		if (current == null)
		{
			return 0;
		}
		int count = 0;
		if (current.value.CompareTo(hi) > 0)
		{
			count++;
		}
		return count + countLessThan(current.left, hi) + countLessThan(current.right, hi);
	}
}