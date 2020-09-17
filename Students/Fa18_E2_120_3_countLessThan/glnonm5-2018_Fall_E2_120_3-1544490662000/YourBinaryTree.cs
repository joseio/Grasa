

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

	/// <exception cref="System.ArgumentException"/>
	public virtual int countLessThan(BinaryTree.Node current, System.IComparable value
		)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		if (current == null)
		{
			return 0;
		}
		int count = 0;
		if (current.value.CompareTo(value) > 0)
		{
			count++;
		}
		return count + countLessThan(current.right, value) + countLessThan(current.left, 
			value);
	}
}