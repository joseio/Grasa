

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

	public virtual int countLessThan(BinaryTree.Node current, System.IComparable value
		)
	{
		int count = 0;
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		if (current == null)
		{
			return 0;
		}
		if (current.left == null && current.right == null)
		{
			if (current.value.CompareTo(value) > 0)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		if (current.value.CompareTo(value) > 0)
		{
			count = 1;
		}
		return count + countLessThan(current.left, value) + countLessThan(current.right, 
			value);
	}
}