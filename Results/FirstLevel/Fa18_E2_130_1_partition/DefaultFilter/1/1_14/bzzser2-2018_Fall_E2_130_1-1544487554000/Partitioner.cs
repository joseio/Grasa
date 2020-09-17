

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int[] result = new int[values.Length];
		int leftP = 0;
		int rightP = values.Length - 1;
		int pivotV = values[0];
		for (int i = values.Length - 1; i >= 0; i--)
		{
			if (values[i] < pivotV)
			{
				result[leftP++] = values[i];
			}
			else
			{
				result[rightP--] = values[i];
			}
		}
		System.Array.Copy(result, 0, values, 0, values.Length);
		return leftP;
	}
}