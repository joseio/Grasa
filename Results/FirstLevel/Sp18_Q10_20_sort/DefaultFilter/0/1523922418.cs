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
		int[] sorted = new int[array.Length];
		for (int i = 0; i <= array.Length - 2; i++)
		{
			if (array[i + 1] < array[i])
			{
				int temp1 = array[i + 1];
				int temp2 = array[i];
				array[i] = temp1;
				array[i + 1] = temp2;
			}
		}
		bool inOrder = true;
		for (int i_1 = 0; i_1 <= array.Length - 2; i_1++)
		{
			if (array[i_1 + 1] < array[i_1])
			{
				inOrder = false;
				break;
			}
		}
		if (inOrder == false)
		{
			return sort(array);
		}
		else
		{
			return array;
		}
	}
}
