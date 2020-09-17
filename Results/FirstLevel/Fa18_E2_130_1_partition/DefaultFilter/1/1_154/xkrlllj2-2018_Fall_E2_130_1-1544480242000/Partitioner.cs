

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivPos = 0;
		int tmp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivPos++;
				tmp = values[i];
				values[i] = values[pivPos];
				values[pivPos] = tmp;
			}
		}
		tmp = values[pivPos];
		values[pivPos] = values[0];
		values[0] = tmp;
		return pivPos;
	}
}