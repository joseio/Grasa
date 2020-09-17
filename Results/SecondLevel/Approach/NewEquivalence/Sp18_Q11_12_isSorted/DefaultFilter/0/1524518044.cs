using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		bool sorted = false;
		int temp = 0;
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = 0; j < array.Length; j++)
			{
				if (i > j)
				{
					temp = i;
					i = j;
					j = temp;
					sorted = true;
				}
			}
		}
		return false;
	}
}
