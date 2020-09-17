

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int lo = 0;
		int pivot = values[0];
		for (int i = lo; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				lo++;
				int tmp = values[lo];
				values[lo] = values[i];
				values[i] = tmp;
			}
		}
		int tmp_1 = values[lo];
		values[lo] = values[0];
		values[0] = tmp_1;
		return lo;
	}
}