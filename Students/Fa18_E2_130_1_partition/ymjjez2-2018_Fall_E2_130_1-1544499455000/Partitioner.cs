

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null)
		{
			return 0;
		}
		if (values.Length == 0)
		{
			return 0;
		}
		int pivotPos = 0;
		int pivotVal = values[0];
		for (int i = 0; i < values.Length; i++)
		{
			if (pivotVal > values[i])
			{
				pivotPos++;
			}
			if (pivotVal <= values[i])
			{
				continue;
			}
		}
		int temp = values[pivotPos];
		values[pivotPos] = pivotVal;
		values[0] = temp;
		for (int i = 0; i < pivotPos; i++)
		{
			for (int j = pivotPos + 1; j < values.Length; j++)
			{
				if (values[i] >= pivotVal)
				{
					if (values[j] < pivotVal)
					{
						int tmp = values[i];
						values[i] = values[j];
						values[j] = tmp;
					}
				}
			}
		}
		return pivotPos;
	}
}