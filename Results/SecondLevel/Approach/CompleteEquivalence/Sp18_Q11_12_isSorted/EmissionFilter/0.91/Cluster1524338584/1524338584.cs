using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		bool sorted = false;
		if (array.Length > 1)
		{
			return sorted;
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] > array[i + 1])
			{
				sorted = true;
			}
			else
			{
				sorted = false;
			}
		}
		return sorted;
	}
}
