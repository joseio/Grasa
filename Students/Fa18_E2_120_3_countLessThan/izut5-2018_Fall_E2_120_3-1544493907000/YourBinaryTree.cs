

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return countLessThan(value, root);
	}

	protected internal virtual int countLessThan(System.IComparable value, BinaryTree.Node
		 current)
	{
		if (current == null)
		{
			return 0;
		}
		int count = 0;
		if (value.CompareTo(current.value) < 0)
		{
			count++;
		}
		if (current.left != null)
		{
			count += countLessThan(value, current.left);
		}
		if (current.right != null)
		{
			count += countLessThan(value, current.right);
		}
		return count;
	}
}