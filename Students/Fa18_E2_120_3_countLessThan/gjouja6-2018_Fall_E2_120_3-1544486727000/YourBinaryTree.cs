

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return recursive(root, value);
	}

	private int recursive(BinaryTree.Node current, System.IComparable value)
	{
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
		}
		if (current.value.CompareTo(value) > 0)
		{
			return 1 + recursive(current.left, value) + recursive(current.right, value);
		}
		else
		{
			return recursive(current.left, value) + recursive(current.right, value);
		}
	}
}