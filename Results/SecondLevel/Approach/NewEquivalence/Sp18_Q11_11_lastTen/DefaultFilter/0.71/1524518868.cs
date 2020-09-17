using System;

/// <summary>Class for storing the last ten integers added.</summary>
/// <remarks>
/// Class for storing the last ten integers added.
/// Your class should be named LastTen.
/// Your class should implement two public methods as described below:
/// 1. void add(int newValue):
/// add a new integer to the values that we are rememebring
/// 2. int[] getLastTen():
/// return the last ten values that were added using add, in any order.
/// If fewer than ten values were added, you should return zeros in their
/// place.
/// Examples:
/// 1. add(1), add(2)
/// getLastTen: [1, 2, 0, 0, 0, ... ]
/// 2. add(0), add(1), add(2), ... add(10)
/// getLastTen: [1, 2, 3, 4, ... 10]
/// Your class should also provide a constructor that takes no arguments.
/// </remarks>
public class LastTen
{
	public int[] original = new int[10];

	public int[] newArray = new int[10];

	public virtual void add(int newValue)
	{
		newArray[0] = newValue;
		int index = 0;
		for (int i = 1; i < newArray.Length; i++)
		{
			newArray[i] = original[index];
			index++;
		}
		original = newArray;
	}

	public virtual int[] getLastTen()
	{
		return newArray;
	}

	public LastTen()
	{
	}
}
