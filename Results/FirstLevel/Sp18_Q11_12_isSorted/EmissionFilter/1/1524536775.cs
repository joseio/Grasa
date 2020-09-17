using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		for (int i = array.Length - 1; i >= 0; i--)
		{
			for (int j = 0; j < i; j++)
			{
				if (array[i] > array[j])
				{
					return false;
				}
			}
		}
		//return true;
		return true;
	}
}
