

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		//return the number if nodes in tree that contain value greater than.
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return countLessThan(value, root);
	}

	public virtual int countLessThan(System.IComparable value, BinaryTree.Node current
		)
	{
		if (current == null)
		{
			return 0;
		}
		if (current.value.CompareTo(value) > 0)
		{
			return 1 + countLessThan(value, current.left) + countLessThan(value, current.right
				);
		}
		return countLessThan(value, current.left) + countLessThan(value, current.right);
	}
}