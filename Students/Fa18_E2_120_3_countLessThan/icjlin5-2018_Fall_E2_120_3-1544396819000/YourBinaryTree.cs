

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

	private int countLessThan(System.IComparable value, BinaryTree.Node a)
	{
		if (a == null)
		{
			return 0;
		}
		if ((value).CompareTo(a.value) < 0)
		{
			return 1 + countLessThan(value, a.left) + countLessThan(value, a.right);
		}
		return 0 + countLessThan(value, a.left) + countLessThan(value, a.right);
	}
}