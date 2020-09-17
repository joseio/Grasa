

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

	private int countLessThan(System.IComparable value, BinaryTree.Node node)
	{
		if (node == null)
		{
			return 0;
		}
		int count = 0;
		if (node.value.CompareTo(value) > 0)
		{
			count++;
		}
		count += countLessThan(value, node.left);
		count += countLessThan(value, node.right);
		return count;
	}
}