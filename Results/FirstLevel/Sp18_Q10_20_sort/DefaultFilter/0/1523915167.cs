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
		int[] newarray = array;
		//System.Console.Out.println(newarray.Length);     <-----ORIG STRING
		Console.WriteLine(newarray.Length);
		int length = array.Length;
		for (int j = 0; j < array.Length; j++)
		{
			for (int i = 1; i < length; i++)
			{
				if (newarray[i] < newarray[i - 1])
				{
					int temp = newarray[i];
					int temp2 = newarray[i - 1];
					newarray[i] = temp2;
					newarray[i - 1] = temp;
				}
			}
		}
		return newarray;
	}
}
