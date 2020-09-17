

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int num = 0;
		int tmp;
		int[] x = new int[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				num++;
				tmp = values[i];
				values[i] = values[num];
				values[num] = tmp;
			}
		}
		tmp = values[0];
		values[0] = values[num];
		values[num] = tmp;
		return num;
	}
}