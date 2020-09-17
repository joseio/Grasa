

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length <= 1)
		{
			return 0;
		}
		for (int i = 0; i < values.Length; i++)
		{
			Console.Write(values[i] + " ");
		}
		Console.WriteLine();
		int pivot = values[0];
		int less = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				less++;
			}
		}
		int[] lower = new int[less];
		int lowCount = 0;
		int[] higher = new int[values.Length - less - 1];
		int highCount = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				lower[lowCount] = values[i];
				lowCount++;
			}
			else
			{
				higher[highCount] = values[i];
				highCount++;
			}
		}
		for (int i = 0; i < lower.Length; i++)
		{
			values[i] = lower[i];
		}
		values[lower.Length] = pivot;
		for (int i = lower.Length + 1; i < values.Length; i++)
		{
			values[i] = higher[i - lower.Length - 1];
		}
		return less;
	}
}