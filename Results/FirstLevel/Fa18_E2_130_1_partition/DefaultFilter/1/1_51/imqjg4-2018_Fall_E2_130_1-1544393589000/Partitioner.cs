

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotposition = 0;
		int pivot = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotposition++;
				int tmp = values[i];
				values[i] = values[pivotposition];
				values[pivotposition] = tmp;
			}
		}
		int tmp_1 = values[0];
		values[0] = values[pivotposition];
		values[pivotposition] = tmp_1;
		return pivotposition;
	}
}