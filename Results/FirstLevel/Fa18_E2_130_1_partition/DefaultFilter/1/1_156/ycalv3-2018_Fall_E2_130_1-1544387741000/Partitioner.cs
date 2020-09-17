

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int lastLessThan = 0;
		bool haveSeenGreater = false;
		for (int i = 1; i < values.Length; i++)
		{
			if (!haveSeenGreater)
			{
				if (values[i] < values[0])
				{
					lastLessThan = i;
				}
				else
				{
					haveSeenGreater = true;
					lastLessThan = i - 1;
				}
			}
			else if (values[i] < values[0])
			{
				int temp = values[i];
				values[i] = values[lastLessThan + 1];
				values[lastLessThan + 1] = temp;
				lastLessThan++;
			}
		}
		int temp_1 = values[0];
		values[0] = values[lastLessThan];
		values[lastLessThan] = temp_1;
		return lastLessThan;
	}
}