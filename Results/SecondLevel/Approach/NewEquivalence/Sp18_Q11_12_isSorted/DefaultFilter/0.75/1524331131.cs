using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			if (i == array.Length - 1)
			{
				break;
			}
			if (array[i] > array[i + 1])
			{
				continue;
			}
			else
			{
				return false;
			}
		}
		return true;
	}
}
