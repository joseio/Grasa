

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int start = 0;
		int end = values.Length;
		int position = 0;
		int pivot = values[start];
		for (int i = start + 1; i < end; i++)
		{
			if (values[i] < pivot)
			{
				position++;
				int temp = values[position];
				values[position] = values[i];
				values[i] = temp;
			}
		}
		int temp_1 = values[position];
		values[position] = values[0];
		values[0] = temp_1;
		return position;
	}
}