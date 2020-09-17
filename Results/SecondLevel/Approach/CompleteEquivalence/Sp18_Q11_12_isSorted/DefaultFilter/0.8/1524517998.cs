using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			int a = array[i];
			for (int j = i; j > 0; j--)
			{
				if (array[j] > a)
				{
					array[i] = array[j];
					array[j] = a;
					return false;
				}
			}
		}
		return true;
	}
}
