

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
		Console.WriteLine(string.Empty);
		int pivot = 0;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < values[0] && pivot < i)
			{
				pivot++;
				int temp = values[pivot];
				values[pivot] = values[i];
				values[i] = temp;
			}
		}
		int temp_1 = values[0];
		values[0] = values[pivot];
		values[pivot] = temp_1;
		for (int i = 0; i < values.Length; i++)
		{
			Console.Write(values[i] + " ");
		}
		Console.WriteLine(" BREAK");
		return pivot;
	}
}