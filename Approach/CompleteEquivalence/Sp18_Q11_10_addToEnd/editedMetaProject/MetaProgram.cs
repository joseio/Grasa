using System.Text.RegularExpressions;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using System.Diagnostics;
using Microsoft.Pex.Framework.Exceptions;
namespace MetaProject
{
    [PexClass(typeof(MetaProgram))]
    public partial class MetaProgram
    {

        public class List
        {
            private int value;
            private List next;

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

            public void addToEnd2(int newValue)
            {
                List current = next;
                if (current == null)
                {
                    current = new List(newValue);
                }
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new List(newValue);
            }

            public void addToEnd3(int newValue)
            {
                List current = this.next;
                if (current == null)
                {
                    current = new List(newValue);
                }
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new List(newValue);
            }



























































            public void addToEndSolution(int newValue)
	{
		if (this.next == null)
		{
			this.next = new List(newValue);
		}
		List current = this.next;
		for (; current.next != null; current = current.next)
		{
		}
		current.next = new List(newValue);
	}



































            public void addToEndSolutionForReal(int newValue)
            {
                List count = this;
                while (count.next != null)
                {
                    count = count.next;
                }
                count.next = new List(newValue);
                return;
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

            public static bool Equals(MetaProgram.List thisObj, MetaProgram.List obj)
            {
                //If not a list
                //if (!(obj is List))
                //    return false;

                if ( obj.Count() != thisObj.Count())
                {
                    return false;
                }
                //Same length
                else
                {
                    //Deep check
                    List current = thisObj;
                    List temp = obj;
                    while (current != null)
                    {
                        //Iterate  
                        if (temp.value != current.value)
                            return false;
                        current = current.next;
                        temp = temp.next;
                    }
                }
                return true;
            }

            public bool Contains(int val)
            {
                //Deep check
                List current = this;
                while (current != null)
                {
                    //Iterate  
                    if (current.value == val)
                        return true;

                    current = current.next;

                }
                return false;
            }
            public int Last()
            {
                //Deep check
                List current = this;
                List last = this;
                while (current != null){
                    
                    last = current;
                    current = current.next;
                }

                return last.value;
            }
        }



        //Testing calling addToEnd MULT times w/ Factory method, 04/15/19


        [PexMethod]
        public static void Check1([PexAssumeUnderTest] MetaProgram.List l, [PexAssumeUnderTest] MetaProgram.List l2, int x)
        {
            PexAssume.IsTrue(MetaProgram.List.Equals(l,l2));
            PexAssume.AreNotSame(l, l2);

            PexAssume.IsTrue(l.Count() <=1);
            
            //int oldCount = l.Count();
            PexObserve.ValueForViewing("old_count", l.Count());
            //PexObserve.ValueForViewing("old_last", l.Last());
            //l.addToEnd(x); //bad
            //l.addToEnd2(x); //bad
            l.addToEnd3(x); //bad
            PexObserve.ValueForViewing("new_count", l.Count());
            //PexObserve.ValueForViewing("new_last", l.Last());
            
            l2.addToEndSolutionForReal(x); //Reference
            PexAssert.IsTrue(MetaProgram.List.Equals(l, l2));
        }
        

        [PexMethod]
        public static void Check([PexAssumeUnderTest] MetaProgram.List l, [PexAssumeUnderTest] MetaProgram.List l2, int x)
        {
            //Use PexAssume.IsTrue instead of Clone(), as not to give Pex any issues
            PexAssume.IsTrue(MetaProgram.List.Equals(l, l2));
            PexAssume.AreNotSame(l, l2); 

            bool firstNull = false;
            bool secondNull = false;

            try
            {
               // for (int i = 0; i < numIterations; i++)
                //{
                    l.addToEnd(x);
                //}
            }
            catch (NullReferenceException)
            {
                firstNull = true;
            }

            try
            {
                //for (int j = 0; j < numIterations; j++)
                //{
                    l2.addToEndSolution(x);
                //}
            }
            catch (NullReferenceException)
            {
                secondNull = true;
            }

            bool passingCondition = ((firstNull == secondNull && firstNull == true) || (firstNull == secondNull && firstNull == false && MetaProgram.List.Equals(l, l2)));
            bool failingCondition = !passingCondition;
            if (failingCondition)
                throw new Exception();

        } 



        //[PexAssumeUnderTest]
        /*[PexMethod]
        public static void Check([PexAssumeNotNull] MetaProgram.List l, [PexAssumeNotNull] MetaProgram.List l2, int x)
        {
            //Use PexAssume.IsTrue instead of Clone(), as not to give Pex any issues
            PexAssume.IsTrue(l.Equals(l2));


            bool firstNull = false;
            bool secondNull = false;

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

            bool passingCondition = ((firstNull == secondNull && firstNull == true) || (firstNull == secondNull && firstNull == false && l2.Equals(l)));
            bool failingCondition = !passingCondition;
            if (failingCondition)
                throw new Exception();
        } */


        
    }
}
