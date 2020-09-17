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
	internal int count = 0;

	internal int[] lastTen = new int[10];

	internal LastTen()
	{
		this.count = 0;
		for (int i = 0; i < lastTen.Length; i++)
		{
			this.lastTen[i] = 0;
		}
	}

	internal virtual void add(int newValue)
	{
		if (this.count == 10)
		{
			this.count = 0;
		}
		this.count++;
		this.lastTen[this.count - 1] = newValue;
	}

	internal virtual int[] getLastTen()
	{
		return this.lastTen;
	}
}
