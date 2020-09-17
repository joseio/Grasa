

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		if (root == null)
		{
			return 0;
		}
		return countLessThan(value, root);
	}

	private int countLessThan(System.IComparable value, BinaryTree.Node current)
	{
		int sum = 0;
		if (current.value.CompareTo(value) > 0)
		{
			sum++;
		}
		if (current.left != null)
		{
			sum += countLessThan(value, current.left);
		}
		if (current.right != null)
		{
			sum += countLessThan(value, current.right);
		}
		return sum;
	}
}