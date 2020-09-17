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
		bool pass = false;
		while (!pass)
		{
			//run until sorted
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i] < array[i - 1])
				{
					int temp = array[i];
					//the ol' switcharoo
					array[i] = array[i - 1];
					array[i - 1] = temp;
				}
			}
			//now we gotta check it it's done yet. 
			pass = true;
			for (int i_1 = 1; i_1 < array.Length; i_1++)
			{
				if (array[i_1] < array[i_1 - 1])
				{
					pass = false;
				}
			}
		}
		return array;
	}
}
