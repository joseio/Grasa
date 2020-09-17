

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
		int temp;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pp++;
				temp = values[pp];
				values[pp] = values[i];
				values[i] = temp;
			}
		}
		temp = values[pp];
		values[pp] = pivot;
		values[0] = temp;
		return pp;
	}
}