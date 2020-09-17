using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			int last = array[0];
			if (last >= array[i])
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
