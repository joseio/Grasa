

public class YourBinaryTree : BinaryTree
{
	/// <exception cref="System.ArgumentException"/>
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		// System.out.println();
		return countLessThan(root, value);
	}

	private int countLessThan(BinaryTree.Node current, System.IComparable value)
	{
		if (current == null)
		{
			// System.out.println(current.value);
			return 0;
		}
		// System.out.println(current.value);
		if (current.value.CompareTo(value) > 0)
		{
			return 1 + countLessThan(current.left, value) + countLessThan(current.right, value
				);
		}
		return countLessThan(current.left, value) + countLessThan(current.right, value);
	}
}