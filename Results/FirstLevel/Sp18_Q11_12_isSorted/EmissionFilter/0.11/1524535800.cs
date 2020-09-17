using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		for (int i = array.Length; i < 1; i--)
		{
			int insert = array[i - 1];
			for (int j = i; j > 0; j--)
			{
				if (array[j - 1] < insert)
				{
					array[j - 1] = array[j];
					array[j] = insert;
				}
			}
		}
		return true;
	}
}
