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
		int[] temp = new int[array.Length];
		temp = array;
		for (int i = 0; i < temp.Length - 1; i++)
		{
			for (int j = 0; j < temp.Length - i - 1; j++)
			{
				if (temp[j] > temp[j + 1])
				{
					int x = temp[j];
					temp[j] = temp[j + 1];
					temp[j + 1] = x;
				}
			}
		}
		return temp;
	}
}
