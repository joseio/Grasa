using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		if (array.Length == 0)
		{
			return true;
		}
		int temp = array[0];
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i] > temp)
			{
				return false;
			}
			temp = array[i];
		}
		return true;
	}
}
