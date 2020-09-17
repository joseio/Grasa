

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		int count = 0;
		if (root == null)
		{
			return 0;
		}
		return countLessThan(root, value);
	}

	private int countLessThan(BinaryTree.Node current, System.IComparable obj)
	{
		int count = 0;
		if (obj.CompareTo(current.value) < 0)
		{
			count++;
		}
		if (current.right != null)
		{
			count += countLessThan(current.right, obj);
		}
		if (current.left != null)
		{
			count += countLessThan(current.left, obj);
		}
		return count;
	}
}