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
		int[] newa = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			newa[i] = array[i];
		}
		while (true)
		{
			bool sorted = true;
			for (int i_1 = 1; i_1 < newa.Length; i_1++)
			{
				if (newa[i_1] < newa[i_1 - 1])
				{
					int temp = newa[i_1];
					newa[i_1] = newa[i_1 - 1];
					newa[i_1 - 1] = temp;
					sorted = false;
				}
			}
			if (sorted == true)
			{
				break;
			}
		}
		return newa;
	}
}
