

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int count = 0;
		int[] toReturn = new int[values.Length];
		int right = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				toReturn[count] = values[i];
				count++;
			}
			else
			{
				right++;
				toReturn[values.Length - right] = values[i];
			}
		}
		toReturn[count] = pivot;
		toReturn[values.Length - right - 1] = pivot;
		for (int i = 0; i < values.Length; i++)
		{
			values[i] = toReturn[i];
		}
		Console.WriteLine(count + " " + pivot + " " + toReturn[count]);
		return count;
	}
}