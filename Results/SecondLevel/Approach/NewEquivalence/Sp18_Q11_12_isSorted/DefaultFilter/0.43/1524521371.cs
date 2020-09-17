using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		int count = 0;
		for (int i = 0; i < array.Length - 1; i++)
		{
			if (array[i] < array[i + 1])
			{
				count++;
			}
		}
		return count == array.Length - 1;
	}
}
