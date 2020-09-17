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
		if (this.next != null)
		{
			this.next.addToEnd(newValue);
		}
		else
		{
			List after = new List(newValue);
			this.next = after;
		}
	}
	/*
	List current = this;
	
	while (this.next != null) {
	current = this.next;
	}
	
	List after = new List(newValue);
	
	current.next = after;
	
	return;
	*/
}