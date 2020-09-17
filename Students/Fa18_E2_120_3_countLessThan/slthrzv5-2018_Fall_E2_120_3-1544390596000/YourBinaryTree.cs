

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

	private int countLessThan(BinaryTree.Node current, System.IComparable value)
	{
		int count = 0;
		if (current == null)
		{
			return count;
		}
		if (current.value.CompareTo(value) > 0)
		{
			count++;
		}
		if (current.left != null)
		{
			count = count + countLessThan(current.left, value);
		}
		if (current.right != null)
		{
			count = count + countLessThan(current.right, value);
		}
		return count;
	}
}