

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotVal = values[0];
		int largBegin = 1;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivotVal)
			{
				// Swap
				int temp = values[largBegin];
				values[largBegin] = values[i];
				values[i] = temp;
				largBegin++;
			}
		}
		int temp_1 = values[largBegin - 1];
		values[largBegin - 1] = pivotVal;
		values[0] = temp_1;
		return largBegin - 1;
	}
}