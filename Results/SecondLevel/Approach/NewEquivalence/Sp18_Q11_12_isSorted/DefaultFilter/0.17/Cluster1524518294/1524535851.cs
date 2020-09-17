using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i + 1] <= array[i])
			{
				return true;
			}
		}
		return false;
	}
}
