using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		bool result = false;
		for (int n = 0; n < array.Length - 1; n++)
		{
			if (array[n] >= array[n + 1])
			{
				result = true;
			}
		}
		return result;
	}
}
