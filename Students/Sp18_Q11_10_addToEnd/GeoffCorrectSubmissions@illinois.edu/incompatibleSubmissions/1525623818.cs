using System;

/// <summary>Class for representing a linked list of ints.</summary>
public class List
{
	public int value;

	public List next;

	public List()
	{
	}

	public List(int setValue)
	{
		value = setValue;
	}

	// public void addToEndHelper(final int newValue, final List node) {
	//     if (node.next == null) {
	//         node.next = new List(newValue);
	//     } else {
	//         addToEndHelper(newValue, node.next);
	//     }
	// }
	// /**
	//  * Add a value as the last item in the list.
	//  *
	//  * Can be called on any item of the list, although will normally be called
	//  * on the first item.
	//  */
	// public void addToEnd(final int newValue) {
	//     addToEndHelper(newValue, this);
	//     return;
	// }
	// public void addToEndHelper(final int newValue, final List node) {
	//     if (node.next == null) {
	//         node.next = new List(newValue);
	//     } else {
	//         addToEndHelper(newValue, node.next);
	//     }
	// }
	// public void addToEnd(final int newValue) {
	//     addToEndHelper(newValue, this);
	//     return;
	// }
	public virtual void addToEndHelper(int newValue, List node)
	{
		if (node.next == null)
		{
			node.next = new List(newValue);
		}
		else
		{
			addToEndHelper(newValue, node.next);
		}
	}

	public virtual void addToEnd(int newValue)
	{
		addToEndHelper(newValue, this);
		return;
	}
}
