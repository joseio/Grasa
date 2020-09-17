

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pp = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pp++;
				int temp = values[i];
				values[i] = values[pp];
				values[pp] = temp;
			}
		}
		int temp_1 = pivot;
		values[0] = values[pp];
		values[pp] = temp_1;
		return pp;
	}
}