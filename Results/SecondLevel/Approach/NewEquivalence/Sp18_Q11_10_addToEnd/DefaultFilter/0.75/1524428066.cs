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
		List now = next;
		if (now == null)
		{
			next = new List(newValue);
			next.next = null;
		}
		for (List now_1 = next; now_1 != null; now_1 = now_1.next)
		{
			if (now_1.next == null)
			{
				now_1.next = new List(newValue);
				now_1.next.next = null;
				break;
			}
		}
		return;
	}
}
