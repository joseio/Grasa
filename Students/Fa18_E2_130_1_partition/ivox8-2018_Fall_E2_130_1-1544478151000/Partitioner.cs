

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int index = 0;
		int temp = 0;
		int position = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i - index] < pivot)
			{
				temp = values[i - index];
				values[i - index] = pivot;
				values[i - 1 - index] = temp;
				position++;
				continue;
			}
			else
			{
				temp = values[i - index];
				values[i - index] = values[values.Length - 1 - index];
				values[values.Length - 1 - index] = temp;
				index++;
			}
		}
		return position;
	}
}