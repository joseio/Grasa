

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return countLessThan(root, value);
	}

	private int countLessThan(BinaryTree.Node curr, System.IComparable value)
	{
		int smaller = 0;
		if (curr == null)
		{
			return smaller;
		}
		if (curr.value.CompareTo(value) > 0)
		{
			smaller++;
		}
		return smaller + countLessThan(curr.right, value) + countLessThan(curr.left, value
			);
	}
}