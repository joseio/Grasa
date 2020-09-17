

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int n = 1;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				int tmp = values[n];
				values[n] = values[i];
				values[i] = tmp;
				n++;
			}
		}
		int tmp_1 = values[n - 1];
		values[n - 1] = values[0];
		values[0] = tmp_1;
		return n - 1;
	}
}