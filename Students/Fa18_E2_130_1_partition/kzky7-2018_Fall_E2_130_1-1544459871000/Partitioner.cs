

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pos = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				values[pos] = values[i];
				pos++;
				int temp = values[pos];
				values[pos] = pivot;
				if (i != pos)
				{
					values[i] = temp;
				}
			}
		}
		return pos;
	}
}