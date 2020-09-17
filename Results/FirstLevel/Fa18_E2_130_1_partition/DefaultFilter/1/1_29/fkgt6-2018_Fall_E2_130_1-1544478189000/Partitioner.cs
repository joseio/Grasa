

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length <= 1)
		{
			return 0;
		}
		int pivot = values[0];
		int index = 1;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				int temp = values[index];
				values[index] = values[i];
				values[i] = temp;
				index++;
			}
		}
		for (int j = 0; j < index - 1; j++)
		{
			values[j] = values[j + 1];
		}
		values[index - 1] = pivot;
		return index - 1;
	}
}