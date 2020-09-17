

public class YourBinaryTree : BinaryTree
{
	protected internal virtual int countLessThan(System.IComparable value, BinaryTree.Node
		 current)
	{
		int count = 0;
		if (current == null)
		{
			return count;
		}
		if (value.CompareTo(current.value) < 0)
		{
			count++;
		}
		return count + countLessThan(value, current.right) + countLessThan(value, current
			.left);
	}

	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return countLessThan(value, root);
	}
}