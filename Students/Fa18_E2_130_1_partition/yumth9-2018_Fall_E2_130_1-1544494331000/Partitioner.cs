

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int a = 0;
		int tmp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				a++;
				tmp = values[i];
				values[i] = values[a];
				values[a] = tmp;
			}
		}
		tmp = values[a];
		values[a] = pivot;
		values[0] = tmp;
		return a;
	}
}