using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		if (array.Length == 1 || array.Length == 0)
		{
			return true;
		}
		int drop = array[0];
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] > drop)
			{
				return false;
			}
			drop = array[i];
		}
		return true;
	}
}
