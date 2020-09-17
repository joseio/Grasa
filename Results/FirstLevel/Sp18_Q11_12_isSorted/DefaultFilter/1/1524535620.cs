using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		for (int index = 1; index < array.Length; index++)
		{
			if (array[index] > array[index - 1])
			{
				return false;
			}
		}
		return true;
	}
}
