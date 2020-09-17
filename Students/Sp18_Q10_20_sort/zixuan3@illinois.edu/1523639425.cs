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
		if (array == null)
		{
			return null;
		}
		int[] ret = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			ret[i] = array[i];
		}
		bool swap = false;
		while (!swap)
		{
			swap = true;
			for (int i_1 = 0; i_1 < ret.Length - 1; i_1++)
			{
				if (ret[i_1] > ret[i_1 + 1])
				{
					int temp = ret[i_1];
					ret[i_1] = ret[i_1 + 1];
					ret[i_1 + 1] = temp;
					swap = false;
				}
			}
		}
		return ret;
	}
}
