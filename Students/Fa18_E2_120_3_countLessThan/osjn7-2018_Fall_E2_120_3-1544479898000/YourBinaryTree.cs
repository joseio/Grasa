

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

	protected internal virtual int countLessThan(System.IComparable value, BinaryTree.Node
		 current)
	{
		if (current == null)
		{
			return 0;
		}
		int count = 0;
		if (current.value.CompareTo(value) > 0)
		{
			count = 1;
		}
		return count + countLessThan(value, current.left) + countLessThan(value, current.
			right);
	}
}