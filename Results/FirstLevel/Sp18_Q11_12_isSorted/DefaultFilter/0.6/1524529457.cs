using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		for (int a = 0; a < array.Length - 2; a++)
		{
			if (!(array[a] >= array[a + 1]))
			{
				return false;
			}
		}
		return true;
	}
}
