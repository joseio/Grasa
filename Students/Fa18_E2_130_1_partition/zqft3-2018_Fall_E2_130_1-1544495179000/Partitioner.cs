

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int partition = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				partition++;
				int a = values[partition];
				values[partition] = values[i];
				values[i] = a;
			}
		}
		int b = values[partition];
		values[partition] = pivot;
		values[0] = b;
		return partition;
	}
}