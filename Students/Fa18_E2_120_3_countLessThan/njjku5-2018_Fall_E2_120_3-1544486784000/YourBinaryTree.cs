

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
		if (current == null)
		{
			return 0;
		}
		int mySum = 0;
		int leftSum = 0;
		int rightSum = 0;
		if (current.value.CompareTo(value) > 0)
		{
			mySum = 1;
		}
		if (current.right != null)
		{
			rightSum = countLessThan(current.right, value);
		}
		if (current.left != null)
		{
			leftSum = countLessThan(current.left, value);
		}
		return mySum + leftSum + rightSum;
	}
}