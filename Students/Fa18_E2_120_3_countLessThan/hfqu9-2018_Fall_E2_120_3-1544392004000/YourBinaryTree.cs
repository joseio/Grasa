

public class YourBinaryTree : BinaryTree
{
	/// <exception cref="System.ArgumentException"/>
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
		if (current == null)
		{
			return 0;
		}
		int count = 0;
		if (value.CompareTo(current.value) < 0)
		{
			count++;
		}
		return count + countLessThan(current.right, value) + countLessThan(current.left, 
			value);
	}
}