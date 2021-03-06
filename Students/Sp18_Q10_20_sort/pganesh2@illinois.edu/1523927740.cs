using System;

public class Program
{
	/// <summary>Sort the array in ascending order.</summary>
	/// <remarks>
	/// Sort the array in ascending order.
	/// You may return either a reference to a new array or to the passed array.
	/// Note that you may not use java.util.Arrays.
	/// </remarks>
	public static int[] sort(int[] array)
	{
		for (int i = 1; i < array.Length; i++)
		{
			int temp = array[i];
			for (int j = i; j > 0; j--)
			{
				if (array[j - 1] > temp)
				{
					array[j] = array[j - 1];
					array[j - 1] = temp;
				}
				else
				{
					break;
				}
			}
		}
		return array;
	}
}
