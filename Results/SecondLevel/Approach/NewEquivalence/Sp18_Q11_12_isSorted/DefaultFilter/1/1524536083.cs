using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		for (int i = 0; i < array.Length - 1; i++)
		{
			int temp = array[i];
			int tempr = array[i + 1];
			if (tempr > temp)
			{
				return false;
			}
		}
		return true;
	}
}
