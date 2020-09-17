

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		return rec(values);
	}

	private static int rec(int[] values)
	{
		int pivot = values[0];
		int pivotP = 0;
		int tmp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotP++;
				tmp = values[pivotP];
				values[pivotP] = values[i];
				values[i] = tmp;
			}
		}
		values[0] = values[pivotP];
		values[pivotP] = pivot;
		return pivotP;
	}
}