

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pp = 0;
		int pivot = values[0];
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				int tmp = values[pp];
				values[pp] = values[i];
				values[i] = tmp;
				pp++;
			}
		}
		int temp = pivot;
		pivot = values[pp];
		values[pp] = temp;
		return pp;
	}
}