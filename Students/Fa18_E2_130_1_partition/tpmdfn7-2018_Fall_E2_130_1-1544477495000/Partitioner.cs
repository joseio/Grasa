

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotindex = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotindex++;
				int temp = values[i];
				values[i] = values[pivotindex];
				values[pivotindex] = temp;
			}
		}
		int temp2 = values[0];
		values[0] = values[pivotindex];
		values[pivotindex] = temp2;
		return pivotindex;
	}
}