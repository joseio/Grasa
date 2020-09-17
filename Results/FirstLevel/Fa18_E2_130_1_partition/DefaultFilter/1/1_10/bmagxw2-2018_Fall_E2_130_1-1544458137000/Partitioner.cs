

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null)
		{
			return 0;
		}
		if (values.Length == 0 || values.Length == 1)
		{
			return 0;
		}
		int position = 0;
		int realPosition = 0;
		int[] sorted = new int[values.Length];
		int pivot = values[0];
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				sorted[position] = values[i];
				position++;
			}
		}
		realPosition = position;
		sorted[position] = pivot;
		position++;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] >= pivot)
			{
				sorted[position] = values[i];
				position++;
			}
		}
		for (int i = 0; i < values.Length; i++)
		{
			values[i] = sorted[i];
		}
		return realPosition;
	}
}