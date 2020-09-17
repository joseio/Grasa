using System;

public class Program
{
	/// <summary>Sort the array in ascending order.</summary>
	/// <remarks>
	/// Sort the array in ascending order.
	/// You may return either a reference to a new array or to the passed array.
	/// </remarks>
	public static int[] sort(int[] array)
	{
		bool swapsMade = false;
		do
		{
			swapsMade = false;
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i - 1] > array[i])
				{
					int tmp = array[i - 1];
					array[i - 1] = array[i];
					array[i] = tmp;
					swapsMade = true;
				}
			}
		}
		while (swapsMade);
		return array;
	}
}
