

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		return countLessThan(value, root);
	}

	protected internal virtual int countLessThan(System.IComparable value, BinaryTree.Node
		 current)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		if (current == null)
		{
			return 0;
		}
		int count = 0;
		if (current.value.CompareTo(value) > 0)
		{
			count++;
		}
		return count + countLessThan(value, current.left) + countLessThan(value, current.
			right);
	}
}