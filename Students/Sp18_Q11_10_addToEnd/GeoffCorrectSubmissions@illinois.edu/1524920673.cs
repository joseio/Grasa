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

	/// <summary>Add a value as the last item in the list.</summary>
	/// <remarks>
	/// Add a value as the last item in the list.
	/// Can be called on any item of the list, although will normally be called
	/// on the first item.
	/// </remarks>
	public virtual void addToEnd(int newValue)
	{
		// save the reference to the header so we can return it.
		List ret = this;
		// loop until we find the end of the list
		while ((ret.next != null))
		{
			ret = ret.next;
		}
		// set the new node to the Object x, next will be null.
		ret.next = new List(newValue);
		ret.next.value = newValue;
		return;
	}
}
