

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotPos = 0;
		int temp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotPos++;
				temp = values[i];
				values[i] = values[pivotPos];
				values[pivotPos] = temp;
			}
		}
		temp = values[pivotPos];
		values[pivotPos] = pivot;
		values[0] = temp;
		return pivotPos;
	}
}