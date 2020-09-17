

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotPos = 0;
		int temp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[pivotPos] > values[i])
			{
				int toMoveLeft = i;
				for (int j = i - 1; j >= pivotPos; j--)
				{
					temp = values[toMoveLeft];
					values[toMoveLeft] = values[j];
					values[j] = temp;
					toMoveLeft--;
				}
				pivotPos++;
			}
		}
		return pivotPos;
	}
}