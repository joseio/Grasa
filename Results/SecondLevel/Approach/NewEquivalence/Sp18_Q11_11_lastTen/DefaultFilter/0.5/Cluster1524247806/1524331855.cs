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
	internal static int storageSpace = 10;

	internal int index = 0;

	internal int[] storage = new int[storageSpace];

	public LastTen()
	{
	}

	public virtual void add(int newValue)
	{
		storage[index % 10] = newValue;
		index++;
	}

	public virtual int[] getLastTen()
	{
		if (index <= 10)
		{
			return storage;
		}
		else
		{
			int[] output = new int[storageSpace];
			int temp = 0;
			for (int i = storageSpace - index % 10 - 1; i < storageSpace; i++)
			{
				output[i] = storage[temp];
				temp++;
			}
			for (int i_1 = 0; i_1 < storageSpace - index % 10 - 1; i_1++)
			{
				output[i_1] = storage[temp];
				temp++;
			}
			//System.out.println(output.toString);
			return output;
		}
	}
}
