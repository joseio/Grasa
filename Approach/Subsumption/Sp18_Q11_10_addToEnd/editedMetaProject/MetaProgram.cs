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

        public class List
        {
            public int value;
            public List next;

            public List() { }

            public List(int setValue)
            {
                value = setValue;
            }

            /**
             * Add a value as the last item in the list.
             *
             * Can be called on any item of the list, although will normally be called
             * on the first item.
             */
            public void addToEnd(int newValue)
	{
		List current = next;
		while (current.next != null)
		{
			current = current.next;
		}
		current.next = new List(newValue);
	}







































































            public void addToEndSolution(int newValue)
	{
		List newElement = new List(newValue);
		for (List current = this; current.next != null; )
		{
			if (current.next.next == null)
			{
				current.next.next = newElement;
				break;
			}
			current = current.next;
		}
	}




















































            public void addToEndSolutionForReal(int newValue)
            {
                if (this.next == null)
                {
                    this.next = new List(newValue);
                }
                else
                {
                    this.next.addToEndSolutionForReal(newValue);
                }
            }

            public int Count()
            {
                int count = 0;

                List current = this;
                while (current != null)
                {
                    count++;
                    current = current.next;
                }
                return count;
            }

            public override bool isEquals(object obj)
            {
                //If not a list
                if (!(obj is List))
                    return false;


                if (((List)obj).Count() != this.Count())
                    return false;
                else // same length
                {
                    //Deep check
                    List current = this;
                    List temp = (List)obj;
                    while (current != null)
                    {
                        if (temp.value != current.value)
                            return false;
                        current = current.next;
                        temp = temp.next; //Iterate
                    }
                }
                return true;
            }
            public List Clone()
            {
                List temp = new List();

                List current = this;
                if (current.Count() == 0)
                    return temp;
                else if (current.Count() == 1)
                {
                    temp.value = current.value;
                    return temp;
                }
                else
                {
                    temp.value = current.value;
                    current = current.next;
                    while (current != null)
                    {
                        temp.addToEndSolutionForReal(current.value);
                        current = current.next;

                    }
                }
                return temp;
            }

        }





[PexMethod]
        public static void Check([PexAssumeNotNull]MetaProgram.List l, int x, Boolean b)
        {
            bool firstNull = false;
            bool secondNull = false;

            List l2 = l.Clone();
            List l3 = l.Clone();

            bool notSubsumption = true;


            try
            {
                l.addToEnd(x);
            }
            catch (NullReferenceException)
            {
                firstNull = true;
            }

            try
            {
                l2.addToEndSolution(x);
            }
            catch (NullReferenceException)
            {
                secondNull = true;
            }

            try
            {
                l3.addToEndSolutionForReal(x);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("addToEndSolutionForReal got  null refence exception!");
            }

            bool passingCondition = ((firstNull == secondNull && firstNull == true) || (firstNull == secondNull && firstNull == false && l2.isEquals(l)));
            bool failingCondition = !passingCondition;
            if (failingCondition)
                throw new Exception("Student submission is equivalent to correct solution, but is not equal to reference submission.");

            //Implement Subsumption PUT
                //Purpose: Determine if subsumption exists across submissions in different child...
                //...clusters within same parent cluster
            if (passingCondition)
            {
                if (b)
                {
                    //s1 >= s2
                    if (l3.isEquals(l))
                        if (!l2.isEquals(l))
                            throw new Exception("Student submission is equivalent to correct solution, but is not equal to reference submission.");
                }
                else
                {
                    //s2 >= s1
                    if (!l3.isEquals(l))
                        if (l3.isEquals(l2))
                            notSubsumption = false;
                }
            }
            //Visualize the val of notSubsumption
            PexObserve.ValueForViewing("notSubsumption", notSubsumption);

            PexAssert.IsTrue(notSubsumption);
        }
    }
}
