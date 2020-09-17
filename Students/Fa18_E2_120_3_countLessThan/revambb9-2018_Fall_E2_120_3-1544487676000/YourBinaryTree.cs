

public class YourBinaryTree : BinaryTree
{
	/// <exception cref="System.ArgumentException"/>
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return countLess(root, value);
	}

	private int countLess(BinaryTree.Node root, System.IComparable value)
	{
		if (root == null)
		{
			return 0;
		}
		int lessLeft = countLess(root.left, value);
		int lessRight = countLess(root.right, value);
		int selfCount = 0;
		if (value.CompareTo(root.value) < 0)
		{
			selfCount = 1;
		}
		return lessLeft + lessRight + selfCount;
	}
}