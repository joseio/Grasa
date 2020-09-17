

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int tmp = 0;
		int position = 0;
		int pivot = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (pivot > values[i])
			{
				position++;
				tmp = values[position];
				values[position] = values[i];
				values[i] = tmp;
			}
		}
		tmp = values[0];
		values[0] = values[position];
		values[position] = tmp;
		return position;
	}
}