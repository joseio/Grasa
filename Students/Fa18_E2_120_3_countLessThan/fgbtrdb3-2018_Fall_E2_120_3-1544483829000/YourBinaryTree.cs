

public class YourBinaryTree : BinaryTree
{
	/// <exception cref="System.ArgumentException"/>
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return countLessThan(value, root);
	}

	private int countLessThan(System.IComparable value, BinaryTree.Node current)
	{
		if (current == null)
		{
			return 0;
		}
		int count = 0;
		if (current.left == null && current.right == null)
		{
			if (value.CompareTo(current.value) < 0)
			{
				count += 1;
			}
		}
		if (current.left != null && current.right == null)
		{
			if (value.CompareTo(current.value) < 0)
			{
				count += 1;
			}
			count += countLessThan(value, current.left);
		}
		if (current.left == null && current.right != null)
		{
			if (value.CompareTo(current.value) < 0)
			{
				count += 1;
			}
			count += countLessThan(value, current.right);
		}
		if (current.left != null && current.right != null)
		{
			if (value.CompareTo(current.value) < 0)
			{
				count += 1;
			}
			count += countLessThan(value, current.left);
			count += countLessThan(value, current.right);
		}
		return count;
	}
}