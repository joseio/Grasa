

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		return countmethod(root, value);
	}

	private int countmethod(BinaryTree.Node node, System.IComparable input)
	{
		if (node == null)
		{
			return 0;
		}
		if (input.CompareTo(node.value) < 0)
		{
			return 1 + countmethod(node.right, input) + countmethod(node.left, input);
		}
		return 0 + countmethod(node.right, input) + countmethod(node.left, input);
	}
}