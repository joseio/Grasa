

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
		int temp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				position++;
				temp = values[position];
				values[position] = values[i];
				values[i] = temp;
			}
		}
		temp = values[position];
		values[position] = values[0];
		values[0] = temp;
		return position;
	}
}