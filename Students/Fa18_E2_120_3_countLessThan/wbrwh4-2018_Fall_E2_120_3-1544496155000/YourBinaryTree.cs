

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return count(root, value);
	}

	public virtual int count(BinaryTree.Node root, System.IComparable value)
	{
		if (root == null)
		{
			return 0;
		}
		int count = 0;
		BinaryTree.Node current = root;
		System.IComparable tmp = current.value;
		if (tmp.CompareTo(value) > 0)
		{
			count = 1;
		}
		return count(current.left, value) + count + count(current.right, value);
	}
}