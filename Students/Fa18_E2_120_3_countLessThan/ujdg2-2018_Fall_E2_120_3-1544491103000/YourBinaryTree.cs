

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

	public virtual int countLessThan(System.IComparable inputValue, BinaryTree.Node current
		)
	{
		if (current == null)
		{
			return 0;
		}
		if (inputValue.CompareTo(current.value) < 0)
		{
			return 1 + countLessThan(inputValue, current.left) + countLessThan(inputValue, current
				.right);
		}
		return countLessThan(inputValue, current.left) + countLessThan(inputValue, current
			.right);
	}
}