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
		bool wasSwitched = false;
		while (wasSwitched)
		{
			wasSwitched = false;
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i - 1] > array[i])
				{
					int tmp = array[i - 1];
					array[i - 1] = array[i];
					array[i] = tmp;
					wasSwitched = true;
				}
			}
		}
		return array;
	}
}
