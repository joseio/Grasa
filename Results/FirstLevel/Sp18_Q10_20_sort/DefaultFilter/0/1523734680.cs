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
		bool swapped = false;
		int[] myArray = array;
		do
		{
			swapped = false;
			for (int i = 0; i < myArray.Length - 1; i++)
			{
				if (myArray[i] > myArray[i + 1])
				{
					swapped = true;
					int temp = myArray[i];
					myArray[i] = myArray[i + 1];
					myArray[i + 1] = temp;
				}
			}
		}
		while (swapped);
		return myArray;
	}
}
