using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = 0; j < array.Length; j++)
			{
				if (array[i] > array[j])
				{
					return true;
				}
			}
		}
		return false;
	}
}
