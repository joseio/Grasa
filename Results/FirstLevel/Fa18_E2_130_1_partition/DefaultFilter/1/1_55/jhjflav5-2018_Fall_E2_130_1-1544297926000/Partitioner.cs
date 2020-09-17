

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
			if (values[i] < pivot)
			{
				values[position] = values[i];
				position++;
				for (int j = i - 1; j >= position; j--)
				{
					values[j + 1] = values[j];
				}
				values[position] = pivot;
			}
		}
		return position;
	}
}