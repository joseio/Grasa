using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		int last = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (i != 0)
			{
				if (array[i] > last)
				{
					return false;
				}
			}
			last = array[i];
		}
		return true;
	}
}
