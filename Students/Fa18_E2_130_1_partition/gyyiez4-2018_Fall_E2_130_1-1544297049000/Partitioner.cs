

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int position = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (pivot > values[i])
			{
				int temp = values[position];
				values[position] = values[i];
				values[i] = temp;
				position++;
			}
		}
		values[position] = pivot;
		return position;
	}
}