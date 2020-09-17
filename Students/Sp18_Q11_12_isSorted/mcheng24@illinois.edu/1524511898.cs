using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		for (int x = 1; x < array.Length; x++)
		{
			if (array[x] > array[x - 1])
			{
				return false;
			}
		}
		return true;
	}
}
