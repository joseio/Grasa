

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int start = 0;
		int end = values.Length;
		int pivot = values[start];
		int pI = 0;
		int temp;
		for (int i = 1; i < end; i++)
		{
			if (values[i] < pivot)
			{
				pI++;
				temp = values[i];
				values[i] = values[pI];
				values[pI] = temp;
			}
		}
		temp = values[pI];
		values[pI] = pivot;
		values[start] = temp;
		return pI;
	}
}