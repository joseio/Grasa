

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null)
		{
			return 0;
		}
		if (values.Length == 0)
		{
			return 0;
		}
		if (values.Length == 1)
		{
			return 0;
		}
		int pivot = values[0];
		int position = 0;
		int tmp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
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