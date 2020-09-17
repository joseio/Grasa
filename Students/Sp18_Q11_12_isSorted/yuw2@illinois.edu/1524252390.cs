using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		int len = array.Length;
		if (len < 2)
		{
			return true;
		}
		if (len > 1)
		{
			for (int i = 0; i < len - 1; i++)
			{
				if (array[i] < array[i + 1])
				{
					return false;
				}
			}
		}
		return true;
	}
}
