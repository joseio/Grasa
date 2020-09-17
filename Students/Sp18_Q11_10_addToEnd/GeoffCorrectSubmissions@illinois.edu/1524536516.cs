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
		List a = new List();
		this.getLast().next = a;
		a.value = newValue;
	}

	public virtual List getLast()
	{
		if (this.next == null)
		{
			return this;
		}
		else
		{
			return this.next.getLast();
		}
	}
}
