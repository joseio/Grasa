

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length < 2)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotPos = 0;
		int j = 1;
		for (int i = 1; i < values.Length; i++)
		{
			j = i;
			if (pivot > values[i])
			{
				while (j > pivotPos)
				{
					Console.WriteLine(j);
					int temp = values[j - 1];
					values[j - 1] = values[j];
					values[j] = temp;
					j--;
				}
				pivotPos++;
			}
		}
		return pivotPos;
	}
}