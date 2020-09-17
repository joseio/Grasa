using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		bool check = false;
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = i + 1; j < array.Length; j++)
			{
				if (array[i] > array[j])
				{
					check = true;
				}
				else
				{
					check = false;
				}
			}
		}
		return check;
	}
}
