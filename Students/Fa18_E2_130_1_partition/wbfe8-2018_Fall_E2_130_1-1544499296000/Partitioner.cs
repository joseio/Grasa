

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
		int tmp;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotposition++;
				tmp = values[pivotposition];
				values[pivotposition] = values[i];
				values[i] = tmp;
			}
		}
		tmp = values[pivotposition];
		values[pivotposition] = values[0];
		values[0] = tmp;
		return pivotposition;
	}
}