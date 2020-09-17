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
		int[] returnarray = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			returnarray[i] = array[i];
		}
		for (int i_1 = 1; i_1 < returnarray.Length; i_1++)
		{
			for (int j = 0; j < i_1; j++)
			{
				if (returnarray[i_1] < returnarray[j])
				{
					int temp = returnarray[i_1];
					returnarray[i_1] = returnarray[j];
					returnarray[j] = temp;
				}
			}
		}
		return returnarray;
	}
}
