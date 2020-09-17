using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		if (array.Length == 0)
		{
			return false;
		}
		for (int i = 0; i <= array.Length; i++)
		{
			if (array[i] >= array[i++])
			{
				return true;
			}
		}
		return false;
	}
}
