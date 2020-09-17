using System;

/// <summary>Class for representing a linked list of ints.</summary>
public class List
{
	public int value;

	public List next;

	public List()
	{
		start = this;
	}

	public List(int setValue)
	{
		start = this;
		value = setValue;
	}

	private List start;

	/// <summary>Add a value as the last item in the list.</summary>
	/// <remarks>
	/// Add a value as the last item in the list.
	/// Can be called on any item of the list, although will normally be called
	/// on the first item.
	/// </remarks>
	public virtual void addToEnd(int newValue)
	{
		List item = new List(newValue);
		if (start == null)
		{
			start = item;
			return;
		}
		List current = start;
		while (current.next != null)
		{
			current = current.next;
		}
		current.next = item;
	}
}
