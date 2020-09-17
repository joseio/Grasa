using System;

/// <summary>Class for storing the last ten integers added.</summary>
/// <remarks>
/// Class for storing the last ten integers added.
/// Your class should be named LastTen.
/// Your class should implement two public methods as described below:
/// 1. void add(int newValue):
/// add a new integer to the values that we are rememebring
/// 2. int[] getLastTen():
/// return the last ten values that were added using add, in any order.
/// If fewer than ten values were added, you should return zeros in their
/// place.
/// Examples:
/// 1. add(1), add(2)
/// getLastTen: [1, 2, 0, 0, 0, ... ]
/// 2. add(0), add(1), add(2), ... add(10)
/// getLastTen: [1, 2, 3, 4, ... 10]
/// Your class should also provide a constructor that takes no arguments.
/// </remarks>
public class LastTen
{
	internal int[] store = new int[0];

	public virtual void add(int newValue)
	{
		int[] newStore = new int[store.Length + 1];
		for (int i = 0; i < store.Length; i++)
		{
			newStore[i] = store[i];
		}
		newStore[newStore.Length - 1] = newValue;
		store = newStore;
	}

	public virtual int[] getLastTen()
	{
		int[] ret = new int[10];
		int count = 0;
		if (store.Length >= 10)
		{
			for (int i = store.Length - 10; i < store.Length; i++)
			{
				ret[count] = store[i];
				count++;
			}
		}
		else
		{
			for (int j = 0; j < store.Length; j++)
			{
				ret[count] = store[j];
				count++;
			}
			for (int k = 1; k <= 10 - store.Length; k++)
			{
				ret[count] = 0;
				count++;
			}
		}
		return ret;
	}
}
