

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return countLess(root, value);
	}

	private int countLess(BinaryTree.Node current, System.IComparable value)
	{
		if (current == null)
		{
			return 0;
		}
		int count = 0;
		if (current.value.CompareTo(value) > 0)
		{
			count++;
		}
		if (current.right == null && current.left == null)
		{
			count += 0;
		}
		if (current.right != null)
		{
			count += countLess(current.right, value);
		}
		if (current.left != null)
		{
			count += countLess(current.left, value);
		}
		countLess(current.left, value);
		countLess(current.right, value);
		return count;
	}
}