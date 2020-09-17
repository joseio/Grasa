using System.Text.RegularExpressions;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using System.Diagnostics;
using Microsoft.Pex.Framework.Exceptions;
using System.IO;

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

            //1524263569.cs
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


            //1525112432.cs
            public virtual void addToEnd4(int newValue)
            {
                if (next == null)
                {
                    next = new List(newValue);
                    return;
                }
                List current = next;
                for (; current.next != null; current = current.next)
                {
                    List second = current.next;
                    if (second.next == null)
                    {
                        second.next = new List(newValue);
                        return;
                    }
                }
                return;
            }


            //1525706850.cs
            public virtual void addToEnd6(int newValue)
            {
                for (List current = next; ; current = current.next)
                {
                    if (current.next == null)
                    {
                        current.next = new List(newValue);
                        break;
                    }
                }
            }


            //1524263866.cs
            public virtual void addToEnd9(int newValue)
            {
                if (next == null && value == 0)
                {
                    value = newValue;
                    return;
                }
                else
                {
                    if (next == null)
                    {
                        next = new List();
                        next.value = newValue;
                        return;
                    }
                    else
                    {
                        next.addToEnd(newValue);
                    }
                }
            }

            //1525739354.cs
            public virtual void addToEnd10(int newValue)
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



       [PexMethod(MaxRunsWithoutNewTests = 500, MaxConstraintSolverTime = 50, MaxBranches = 50000, Timeout = 500)]
        public static void Check([PexAssumeUnderTest] MetaProgram.List l, [PexAssumeUnderTest] MetaProgram.List l4,
           [PexAssumeUnderTest] MetaProgram.List l6, [PexAssumeUnderTest] MetaProgram.List l9,
           [PexAssumeUnderTest] MetaProgram.List l10, [PexAssumeUnderTest] MetaProgram.List lSoln, int x)
        {
            /*PexAssume.IsTrue(MetaProgram.List.Equals(l, l4));
            PexAssume.IsTrue(MetaProgram.List.Equals(l4, l6));
            PexAssume.IsTrue(MetaProgram.List.Equals(l6, l9));
            PexAssume.IsTrue(MetaProgram.List.Equals(l9, l10));
            PexAssume.IsTrue(MetaProgram.List.Equals(l10, lSoln));*/

            //PexAssume.AreDistinctReferences(new Object[] { l, l4, l6, l9, l10, lSoln });

            PexAssume.IsTrue(MetaProgram.List.Equals(l9, lSoln));
            PexAssume.AreDistinctReferences(new Object[] { l9, lSoln });
         
            bool firstNull = false;
            bool fourNull = false;
            bool sixNull = false;
            bool nineNull = false;
            bool tenNull = false;
            bool solnNull = false;

            int count = 0;

           /*
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
                l4.addToEnd4(x);
            }
            catch (NullReferenceException)
            {
                fourNull = true;
            }
           
           

           
            try
            {
                l6.addToEnd6(x);
            }
            catch (NullReferenceException)
            {
                sixNull = true;
            }
            
           */

            try
            {
                l9.addToEnd9(x);
            }
            catch (NullReferenceException)
            {
                nineNull = true;
            }
           /*
            try
            {
                l10.addToEnd10(x);
            }
            catch (NullReferenceException)
            {
                tenNull = true;
            } 
            * */
            
            try
            {
                lSoln.addToEndSolutionForReal(x);
            }
            catch (NullReferenceException)
            {
                solnNull = true;
            }
           
           /*
            bool passingCondition1 = ((firstNull == solnNull && firstNull == true) || (firstNull == solnNull && firstNull == false && MetaProgram.List.Equals(l, lSoln)));
            bool failingCondition1 = !passingCondition1;
            if (failingCondition1)
            {
                count++;
                Console.WriteLine("sub1 not equal to instructor soln");
            }
           
           
           
            bool passingCondition4 = ((fourNull == solnNull && fourNull == true) || (fourNull == solnNull && fourNull == false && MetaProgram.List.Equals(l4, lSoln)));
            bool failingCondition4 = !passingCondition4;
            if (failingCondition4)
            {
                count++;
                Console.WriteLine("sub4 not equal to instructor soln");
            }

          

            bool passingCondition6 = ((sixNull == solnNull && sixNull == true) || (sixNull == solnNull && sixNull == false && MetaProgram.List.Equals(l6, lSoln)));
            bool failingCondition6 = !passingCondition6;
            if (failingCondition6)
            {
                count++;
                Console.WriteLine("sub6 not equal to instructor soln");
            }
           
           */
            bool passingCondition9 = ((nineNull == solnNull && nineNull == true) || (nineNull == solnNull && nineNull == false && MetaProgram.List.Equals(l9, lSoln)));
            bool failingCondition9 = !passingCondition9;
            if (failingCondition9)
            {
                count++;
                Console.WriteLine("sub9 not equal to instructor soln");
            }
           /*
            bool passingCondition10 = ((tenNull == solnNull && tenNull == true) || (tenNull == solnNull && tenNull == false && MetaProgram.List.Equals(l10, lSoln)));
            bool failingCondition10 = !passingCondition10;
            if (failingCondition10)
            {
                count++;
                Debug.WriteLine("sub10 not equal to instructor soln");
            } 
           */
           

            PexObserve.ValueForViewing("count", count);
            
            PexAssert.IsTrue(count == 1); //<------ SUBJECT TO CHANGE!!!!

        }

       static void printResultToFile(string stringToPrint)
       {
           string path = Path.GetFullPath(Path.Combine(@"C:\Users\rayjo\Documents\GitHub\Re-organizing BitBucket\Approach\CompleteEquivalence\Sp18_Q11_10_addToEnd\editedMetaProject_TRUE_Minimization", @"TrulyKilled.txt"));
           if (!File.Exists(path))
           {
               File.Create(path).Dispose();
               using (TextWriter tw = new StreamWriter(path))
               {
                   tw.WriteLine(stringToPrint);
               }
           }
           else if (File.Exists(path))
           {
               using (TextWriter tw = new StreamWriter(path, true))
               {
                   tw.WriteLine(stringToPrint);
               }
           }
       }
    }
}
