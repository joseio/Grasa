

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int i = -1;
		for (int j = 0; j < values.Length; j++)
		{
			if (pivot > values[j])
			{
				i++;
				int temp = values[j];
				values[j] = values[i];
				values[i] = temp;
			}
		}
		values[i + 1] = pivot;
		return i + 1;
	}
}