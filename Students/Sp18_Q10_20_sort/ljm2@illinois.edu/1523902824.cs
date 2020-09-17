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
		int[] returnArray = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			returnArray[i] = array[i];
		}
		for (int j = 0; j < returnArray.Length; j++)
		{
			for (int i_1 = 0; i_1 < returnArray.Length - 1; i_1++)
			{
				if (returnArray[i_1] > returnArray[i_1 + 1])
				{
					int temp = returnArray[i_1 + 1];
					returnArray[i_1 + 1] = returnArray[i_1];
					returnArray[i_1] = temp;
				}
			}
		}
		return returnArray;
	}
}
