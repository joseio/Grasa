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
	public static int[] output;

	public LastTen()
	{
		output = new int[0];
	}

	public static void add(int newValue)
	{
		int[] newarray = new int[output.Length + 1];
		for (int i = 0; i < output.Length - 1; i++)
		{
			newarray[i] = output[i];
		}
		newarray[newarray.Length - 1] = newValue;
		output = newarray;
	}

	public virtual int[] getLastTen()
	{
		if (output.Length < 10)
		{
			int count = 10 - output.Length;
			for (int i = 0; i < count; i++)
			{
				LastTen.add(0);
			}
			return output;
		}
		int[] result = new int[10];
		int count_1 = 0;
		for (int i_1 = output.Length - 10; i_1 < output.Length; i_1++)
		{
			result[count_1] = output[i_1];
			count_1++;
		}
		return result;
	}
}
