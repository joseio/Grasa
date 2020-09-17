

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0 || values.Length == 1)
		{
			return 0;
		}
		int pivPoint = 1;
		int checkVal = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < checkVal)
			{
				int temp = values[i];
				values[i] = values[pivPoint];
				values[pivPoint] = temp;
				pivPoint++;
			}
		}
		values[0] = values[pivPoint - 1];
		values[pivPoint - 1] = checkVal;
		return pivPoint - 1;
	}
}