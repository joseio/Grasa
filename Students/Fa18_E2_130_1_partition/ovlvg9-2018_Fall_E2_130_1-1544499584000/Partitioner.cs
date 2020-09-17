

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotPo = 0;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				int tmp = values[pivotPo];
				values[pivotPo] = values[i];
				values[i] = tmp;
				pivotPo++;
			}
		}
		int tmp_1 = pivot;
		pivot = values[pivotPo];
		values[pivotPo] = tmp_1;
		return pivotPo;
	}
}