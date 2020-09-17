using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
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
					return true;
				}
			}
		}
		return false;
	}
}
