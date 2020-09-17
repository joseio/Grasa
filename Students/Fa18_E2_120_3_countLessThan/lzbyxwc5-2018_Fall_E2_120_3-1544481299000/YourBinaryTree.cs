

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

	private int countLessThan(BinaryTree.Node current, System.IComparable value)
	{
		int count = 0;
		if (current == null)
		{
			return 0;
		}
		else if (value == null)
		{
			throw new System.ArgumentException();
		}
		else if (current.value.CompareTo(value) > 0)
		{
			count++;
		}
		return count + countLessThan(current.right, value) + countLessThan(current.left, 
			value);
	}
}