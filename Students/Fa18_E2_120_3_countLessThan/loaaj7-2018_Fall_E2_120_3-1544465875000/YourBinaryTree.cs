

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

	private int countLessThan(BinaryTree.Node node, System.IComparable value)
	{
		if (node == null)
		{
			return 0;
		}
		int contributionFromNode;
		if (value.CompareTo(node.value) < 0)
		{
			contributionFromNode = 1;
		}
		else
		{
			contributionFromNode = 0;
		}
		return contributionFromNode + countLessThan(node.left, value) + countLessThan(node
			.right, value);
	}
}