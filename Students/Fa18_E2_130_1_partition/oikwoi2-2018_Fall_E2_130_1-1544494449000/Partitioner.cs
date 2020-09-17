

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int tmp;
		int pos = 0;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pos++;
				tmp = values[pos];
				values[pos] = values[i];
				values[i] = tmp;
			}
		}
		tmp = values[pos];
		values[pos] = pivot;
		values[0] = tmp;
		return pos;
	}
}