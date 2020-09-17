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
		int temp = 0;
		int move = 0;
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i] < array[i - 1])
			{
				temp = array[i];
				for (int j = i - 1; j >= 0; j--)
				{
					if (temp <= array[j])
					{
						move = array[j];
						array[j] = temp;
						array[j + 1] = move;
					}
				}
			}
		}
		return array;
	}
}
