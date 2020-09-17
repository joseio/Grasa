using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		int count = 1;
		if (array == null)
		{
			return true;
		}
		for (int i = array.Length - 1; i >= 1; i--)
		{
			if (array[i] <= array[i--])
			{
				count++;
			}
			if (count == array.Length)
			{
				return true;
			}
		}
		return false;
	}
}
