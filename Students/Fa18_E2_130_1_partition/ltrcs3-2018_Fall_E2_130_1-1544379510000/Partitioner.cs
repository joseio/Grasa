

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotPos = 0;
		for (int i = 1; i < values.Length; i++)
		{
			// if less than, move to left
			if (values[i] < values[pivotPos])
			{
				// swap with pivotPos, then increment pivotPos
				for (int j = i; j > pivotPos; j--)
				{
					int tmp = values[j];
					values[j] = values[j - 1];
					values[j - 1] = tmp;
				}
				pivotPos++;
			}
		}
		return pivotPos;
	}
}