

public class YourBinaryTree : BinaryTree
{
	protected internal override int countLessThan(System.IComparable value)
	{
		if (value == null)
		{
			throw new System.ArgumentException();
		}
		else if (this.root == null)
		{
			return 0;
		}
		else
		{
			return countLessThan(value, this.root);
		}
	}

	private int countLessThan(System.IComparable pvalue, BinaryTree.Node current)
	{
		if (current == null)
		{
			return 0;
		}
		if (pvalue.CompareTo(current.value) < 0)
		{
			return 1 + countLessThan(pvalue, current.left) + countLessThan(pvalue, current.right
				);
		}
		else
		{
			return countLessThan(pvalue, current.left) + countLessThan(pvalue, current.right);
		}
	}
}