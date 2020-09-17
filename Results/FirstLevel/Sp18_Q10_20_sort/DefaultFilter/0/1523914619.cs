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
		bool switched = false;
		int[] newAr = array;
		for (int i = 0; i < newAr.Length - 1; i++)
		{
			if (newAr[i] > newAr[i + 1])
			{
				int temp = newAr[i + 1];
				newAr[i + 1] = newAr[i];
				newAr[i] = temp;
				switched = true;
			}
		}
		if (switched == true)
		{
			return sort(newAr);
		}
		else
		{
			return newAr;
		}
	}
}
