using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		int i = 0;
		while (i < array.Length - 1)
		{
			if (array[i + 1] < array[i])
			{
				i++;
			}
			else
			{
				break;
			}
			return true;
		}
		return false;
	}
}
