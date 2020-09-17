

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotVal = values[0];
		int pivotPos = 0;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivotVal)
			{
				pivotPos++;
				int temp = values[pivotPos];
				values[pivotPos] = values[i];
				values[i] = temp;
			}
		}
		values[0] = values[pivotPos];
		values[pivotPos] = pivotVal;
		return pivotPos;
	}
}