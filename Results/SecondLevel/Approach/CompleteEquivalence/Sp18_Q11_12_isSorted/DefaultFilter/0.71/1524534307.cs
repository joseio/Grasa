using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		int last = array[0];
		for (int i = 1; i < array.Length; i++)
		{
			if (last > array[i])
			{
				last = array[i];
			}
			else
			{
				return false;
			}
		}
		return true;
	}
}
