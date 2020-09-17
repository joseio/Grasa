

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		for (int i = 0; i < values.Length; i++)
		{
			Console.Write(values[i] + " ");
		}
		int[] newValues = values;
		int j = 0;
		int k = 0;
		int pivot = values[j];
		for (int i = 1; i < values.Length; i++)
		{
			if (newValues[i] < pivot)
			{
				j++;
				values[j - 1] = newValues[i];
			}
			else
			{
				k++;
				values[values.Length - k] = newValues[i];
			}
		}
		values[j] = pivot;
		Console.WriteLine();
		for (int i = 0; i < values.Length; i++)
		{
			Console.Write(values[i] + " ");
		}
		Console.WriteLine(values.Length + " asdfasdfa " + j + " dafs " + k);
		return j;
	}
}