

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int smallCount = 0;
		int pivot = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				int tmp = values[i];
				values[i] = values[smallCount + 1];
				values[smallCount + 1] = tmp;
				smallCount++;
			}
		}
		values[0] = values[smallCount];
		values[smallCount] = pivot;
		return smallCount;
	}
}