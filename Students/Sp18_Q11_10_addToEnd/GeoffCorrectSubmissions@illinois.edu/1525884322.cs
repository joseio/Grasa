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
		//public List start;
		value = setValue;
	}

	/// <summary>Add a value as the last item in the list.</summary>
	/// <remarks>
	/// Add a value as the last item in the list.
	/// Can be called on any item of the list, although will normally be called
	/// on the first item.
	/// </remarks>
	public virtual void addToEnd(int newValue)
	{
		// if (start == null) {
		//     start = new List(newValue);
		// }
		List last = new List(newValue);
		last.next = null;
		List current = this;
		while (current.next != null)
		{
			current = current.next;
		}
		current.next = last;
	}
	// if (next == null) {
	//     next = new Lsit(newValue);
	//     next.next = null;
	//     //next.List(newValue);
	// }
	// if (next != null) {
	//     next.addToEnd(newValue);
	// }
}
