using System;

public class Program
{
	/// <summary>Sort the array in ascending order.</summary>
	/// <remarks>
	/// Sort the array in ascending order.
	/// You may return either a reference to a new array or to the passed array.
	/// Note that you may not use
	/// </remarks>
	public static int[] sort(int[] array)
	{
		int[] result = array;
		bool change = true;
		while (change)
		{
			change = false;
			for (int i = 1; i < result.Length; i++)
			{
				if (result[i] < result[i - 1])
				{
					int temp = result[i];
					result[i] = result[i - 1];
					result[i - 1] = temp;
					change = true;
				}
			}
		}
		return result;
	}
	//return null;
}
