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
	public LastTen()
	{
	}

	internal int[] temp = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

	public virtual void add(int newValue)
	{
		for (int i = 9; i >= 0; i--)
		{
			if (temp[i] == -1)
			{
				temp[i] = newValue;
				return;
			}
		}
		for (int i_1 = 0; i_1 < 9; i_1++)
		{
			temp[i_1] = temp[i_1 + 1];
		}
		temp[9] = newValue;
		return;
	}

	public virtual int[] getLastTen()
	{
		for (int i = 0; i < 10; i++)
		{
			if (temp[i] == -1)
			{
				temp[i] = 0;
			}
		}
		return temp;
	}
}
