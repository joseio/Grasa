using System.Text.RegularExpressions;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using System.Diagnostics;

namespace MetaProject
{
    [PexClass(typeof(MetaProgram))]
    public partial class MetaProgram
    {

        public class LastTen
{
	public int[] tenArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	public LastTen()
	{
	}
	public virtual void add(int newValue)
	{
		for (int i = 0; i < 9; i++)
		{
			tenArray[i] = tenArray[i + 1];
		}
		tenArray[10] = newValue;
	}
	public virtual int[] getLastTen()
	{
		return tenArray;
	}
}





















































            //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
            [PexMethod]
            public static void Check([PexAssumeNotNull] int[] inputArr, int x, Boolean b)
            {
                // IDEA FROM ZIRUI: Pass in array rather than type LastTen to Check()...THEN construct 3 diff types
                // This way we won't need the Clone() method to polute student's code

                LastTen sub1Arr = new LastTen();
                sub1Arr.tenArray = inputArr; //TODO: Replace LastTen class' "array" variable!!

                LastTenSolution sub2Arr = new LastTenSolution();
                sub2Arr.array = inputArr; //TODO: Replace LastTenSolution class' "array" variable!!

                LastTenSolutionForReal sub3Arr = new LastTenSolutionForReal();
                sub3Arr.array = inputArr;

                bool firstNull = false, secondNull = false;

                try
                {
                    sub1Arr.add(x);
                }
                catch (IndexOutOfRangeException)
                {
                    firstNull = true;
                }

                try
                {
                    sub2Arr.add(x);
                }
                catch (IndexOutOfRangeException)
                {
                    secondNull = true;
                }

                try
                {
                    sub1Arr.add(x);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("addSolutionForReal got index out of range!");
                }


                //bool passingCondition = ((firstNull == secondNull && firstNull == true) || (firstNull == secondNull && firstNull == false && l2.Equals(l)));
                bool passingCondition = ((firstNull == secondNull && firstNull == true) || (firstNull == secondNull && firstNull == false) && sub2Arr.getLastTen().Equals(sub1Arr.getLastTen()));
                bool failingCondition = !passingCondition;
                if (failingCondition)
                    throw new Exception();

                if (passingCondition)
                {
                    //Implement Tao's PUT:
                    if (b) //Bool to force Pex to explore diff paths
                    {
                        if (sub3Arr.getLastTen().Equals(sub1Arr.getLastTen()))
                            if (!sub2Arr.getLastTen().Equals(sub1Arr.getLastTen()))
                                throw new Exception();
                    }
                    else
                    {
                        if (sub3Arr.getLastTen().Equals(sub2Arr.getLastTen()))
                            if (!sub2Arr.getLastTen().Equals(sub1Arr.getLastTen()))
                                throw new Exception();
                    }
                }
            }
        }























    public class LastTenSolution
{
	internal int[] array = new int[0];
	public virtual void add(int newValue)
	{
		int[] newStore = new int[array.Length + 1];
		for (int i = 0; i < array.Length; i++)
		{
			newStore[i] = array[i];
		}
		newStore[newStore.Length - 1] = newValue;
		array = newStore;
	}
	public virtual int[] getLastTen()
	{
		int[] ret = new int[10];
		int count = 0;
		for (int i = array.Length - 11; i < array.Length; i++)
		{
			ret[count++] = array[i];
		}
		return ret;
	}
	public LastTenSolution()
	{
		{
		}
	}
}





















    public class LastTenSolutionForReal
    {
        public int[] array = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public LastTenSolutionForReal()
        {
        }

        public virtual void add(int newValue)
        {
            for (int i = 0; i < 9; i++)
            {
                array[i] = array[i + 1];
            }
            array[9] = newValue;
        }

        public virtual int[] getLastTen()
        {
            return array;
        }
    }
}
