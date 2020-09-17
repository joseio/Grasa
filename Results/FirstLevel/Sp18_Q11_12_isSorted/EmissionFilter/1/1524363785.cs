using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		if (array.Length == 1)
		{
			//Ya got me, Geoff!
			return true;
		}
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i] > array[i - 1])
			{
				return false;
			}
		}
		return true;
	}
}
