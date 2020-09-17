

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int low = 1;
		int high = values.Length;
		int pivot = 0;
		int i = low - 1;
		for (int j = low; j < high; j++)
		{
			if (values[j] < values[pivot])
			{
				i++;
				int temp = values[j];
				values[j] = values[i];
				values[i] = temp;
			}
		}
		int temp_1 = values[i];
		values[i] = values[pivot];
		values[pivot] = temp_1;
		return i;
	}
}