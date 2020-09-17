

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length <= 1)
		{
			return 0;
		}
		int pivot = values[0];
		int position = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				position++;
				int temp = values[i];
				values[i] = values[position];
				values[position] = temp;
			}
		}
		int temp_1 = values[position];
		values[position] = pivot;
		values[0] = temp_1;
		return position;
	}
}