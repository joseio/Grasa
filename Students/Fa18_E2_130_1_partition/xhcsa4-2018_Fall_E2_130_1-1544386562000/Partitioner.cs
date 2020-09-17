

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
		int temp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pos++;
				temp = values[pos];
				values[pos] = values[i];
				values[i] = temp;
			}
		}
		temp = values[pos];
		values[pos] = pivot;
		values[0] = temp;
		return pos;
	}
}