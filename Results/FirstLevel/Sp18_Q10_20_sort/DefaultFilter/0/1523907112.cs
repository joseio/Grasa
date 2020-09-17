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
		int a = array.Length;
		for (int i = 1; i < a; i++)
		{
			for (int j = i; j > 0; j--)
			{
				if (array[j] < array[j - 1])
				{
					int c = array[j];
					array[j] = array[j - 1];
					array[j - 1] = c;
				}
			}
		}
		return array;
	}
}
