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
	/// <summary>Sets the array of integrers to an empty array of size 10.</summary>
	public static int[] lastTen = new int[10];

	/// <summary>A constructor that sets the values to be empty.</summary>
	/// <param name="newValue">- the new value to add</param>
	public virtual void add(int newValue)
	{
		int[] temp = new int[lastTen.Length];
		for (int i = 0; i < lastTen.Length; i++)
		{
			temp[i] = lastTen[i];
		}
		for (int i_1 = 1; i_1 < lastTen.Length; i_1++)
		{
			lastTen[i_1] = temp[i_1 - 1];
		}
		lastTen[0] = newValue;
	}

	public virtual int[] getLastTen()
	{
		return lastTen;
	}

	public LastTen()
	{
		{
			for (int i = 0; i < 10; i++)
			{
				lastTen[i] = 0;
			}
		}
	}
}
