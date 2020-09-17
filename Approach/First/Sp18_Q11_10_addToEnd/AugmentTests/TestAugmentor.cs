using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetaProject;
using System.IO;
using Pex4Fun;

/* References:
 * https://stackoverflow.com/questions/34350020/loop-through-each-sub-directories-in-sub-directories
 * https://stackoverflow.com/questions/289/how-do-you-sort-a-dictionary-by-value
 * https://stackoverflow.com/questions/3066182/convert-an-iorderedenumerablekeyvaluepairstring-int-into-a-dictionarystrin
 * https://stackoverflow.com/questions/10443461/c-sharp-array-findallindexof-which-findall-indexof
 * https://www.dotnetperls.com/sort-dictionary
 * 
 * TIP: 
 * May need to run w/o debugging (Ctrl + F5)
 */

namespace AugmentTests
{
    class TestAugmentor
    {
        static string currDir = System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString();
        static string augmentTestDir = Path.GetFullPath(Path.Combine(currDir, @"..\"));
        static string candidateTestFilePath = Path.GetFullPath(Path.Combine(augmentTestDir, @"..\CandidateTest\Candidate.cs"));

        public static void Main(string[] args)
        {
            
            string failedTestDir = augmentTestDir + @"FailedTests\";
            string submissionsDir = augmentTestDir + @"SubmissionsUnderTest\";
            string metaProjectDir = Path.GetFullPath(Path.Combine(augmentTestDir, @"..\editedMetaProject\"));
            string metaProgramFilePath = metaProjectDir + "MetaProgram.cs";
            string assemblyName = "meta_project1525456207";
            //Put all Pex-generated tests into dictionary
            Dictionary<string, int> candidateTests = getAllFailingTestDirectories(failedTestDir);
            //Sort dictionary by value, descending order
            var sortedCandidates = from pair in candidateTests
                                   orderby pair.Value descending
                                   select pair;
            //Get full paths of all submissions under test
            string[] submissions = Directory.GetFiles(submissionsDir, ".cs", SearchOption.AllDirectories); //".cs" denotes file format
            
            
            foreach (var myCandidate in sortedCandidates)
            {
                //Replace candidate test method, starting w/ test that occured most frequently
                replaceCandidateTest(myCandidate);

                //Loop through each submission
                foreach (var submissionPath in submissions)
                {
                    //Replace student's submission in editedMetaProject
                    replaceStudentSubmission(submissionPath, metaProgramFilePath);
                    //Re-build editedMetaProject
                    if (BuildDirectory.BuildSingleProject(metaProjectDir, true))
                    {
                        //Below line ensures that TestAugmentor uses most updated ver. of editedMetaProject's asembly file
                        Pex4Fun.Program.copyOverAssemblyFile(metaProjectDir, currDir, assemblyName);

                        //Call candidateTest()
                        try
                        {
                            candidateTest();
                            Console.WriteLine("Submission did NOT fail this test!!");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Submission failed this test!! NICE! Had following exception:");
                            Console.WriteLine(e.ToString());

                            //TODO: 
                            //Implement logic to increm #submissions failing the test and exclude them from next round
                        }
                    }
                }

            }

            /* Steps:
             * 1. Get dictionary of all candidate tests from files (DONE)
             * 1. Paste candidate check method into candidateTest() (DONE)
             * 2. Recompile editedMetaProject solution each time I replace (DONE)
             * 3. 
             * 2. For loop:
                * a. Paste student submission into editedMetaProject's addToEnd() [DONE]
                * b. Call candidateTest() [DONE]
                * c. Increm #submissions failing the test and exclude them from next round (put in list)
             * 3. Print test to be added to test suite
                * Format: 
                List list = new List(0);
                List copy = new List(0);
                for (int i = 0; i < times; i++)
                {
                    addToEnd(copy, 0); //Instructor solution
                    addToEnd(0); //Student submission
                }
                * Where 'times' = (last param. of Check method) + (#occurences of '*.value' b/t 's0.value' and 's0.next') 
             */
        }

       

        public static void replaceStudentSubmission(string submissionFilePath, string metaProgramFilePath)
        {
            string[] submissionFileText = File.ReadAllLines(submissionFilePath);
            //Delete method header 'public void...'
            submissionFileText[0] = "";
            //Remove empty lines
            submissionFileText.Where(x => !string.IsNullOrEmpty(x)).ToArray(); //Still contains "{}"

            string[] metaProgramFileText = File.ReadAllLines(metaProgramFilePath);
            int startIndx = Array.IndexOf(metaProgramFileText, "public void addToEnd(");
            int endIndx = Array.IndexOf(metaProgramFileText, "}", startIndx);
            //Delete contents of addToEnd(), including "{}"
            Array.Clear(metaProgramFileText, startIndx + 1, (endIndx - startIndx + 1));
            StringBuilder sb = new StringBuilder();
            //Copy to StringBuilder
            foreach (var line in metaProgramFileText)
            {
                sb.AppendLine(line);
                //Insert the candidate test just below "candidateTest()"
                if (line.Contains("public void addToEnd("))
                {
                    foreach (var submissionLine in submissionFileText)
                    {
                        sb.AppendLine(submissionLine);
                    }
                }
            }
            File.WriteAllText(metaProgramFilePath, sb.ToString());
        }

        public static void candidateTest()
        {
            //Add 
        }

        public static void replaceCandidateTest(KeyValuePair<string, int> myCandidate)
        {
            string[] testAugmentorFileText = File.ReadAllLines(candidateTestFilePath);
            int startIndx = Array.IndexOf(testAugmentorFileText, "static void candidateTest()");
            int endIndx = Array.IndexOf(testAugmentorFileText, "}", startIndx);
            //Delete contents of candidateTest, including "{}"
            Array.Clear(testAugmentorFileText, startIndx + 1, (endIndx - startIndx + 1));
            StringBuilder sb = new StringBuilder();
            //Copy to StringBuilder
            foreach (var line in testAugmentorFileText) 
            {
                sb.AppendLine(line);
                //Insert the candidate test just below "candidateTest()"
                if (line.Contains("static void candidateTest()"))
                {
                    //Split treats string like string[] to iterate line-by-line vs. char-by-char
                    foreach (var testLine in myCandidate.Key.Split('\n'))
                    {
                        sb.AppendLine(testLine);
                    }
                }
            }
            File.WriteAllText(candidateTestFilePath, sb.ToString());
        }

        public static Dictionary<string, int> getAllFailingTestDirectories(string failedTestDir)
        {
            Dictionary<string, int> myDict = new Dictionary<string, int>();
            string[] failedTestFiles = Directory.GetFiles(failedTestDir, "*", SearchOption.AllDirectories); //"*" denotes any file format
            foreach (var myFile in failedTestFiles)
            {
                string[] myFileText = File.ReadAllLines(myFile);

                int[] openBraceIndices = myFileText.Select((b, i) => b == "{" ? i : -1).Where(i => i != -1).ToArray();
                int[] closedBraceIndices = myFileText.Select((b, i) => b == "}" ? i : -1).Where(i => i != -1).ToArray();
                for (int i = 0; i < openBraceIndices.Length; i++)
                {
                    //Get str array of candidate tests and strip "{}"
                    var newArr = myFileText.Skip(openBraceIndices[i] + 1).Take(closedBraceIndices[i] - 1).ToArray();
                    //Clean a second time to catch ending braces that weren't deleted
                    int[] secondClosedBraceIndx = newArr.Select((b, j) => b == "}" ? j : -1).Where(j => j != -1).ToArray();
                    if (secondClosedBraceIndx.Length != 0)
                        newArr = newArr.Skip(0).Take(secondClosedBraceIndx[0]).ToArray();
                    //Conv string[] -> string, preserving '\n'
                    newArrStr = String.Join("", newArr);
                    //Add new entry if not already existing in dictionary w/ #occurences = 1
                    if (!myDict.ContainsKey(newArrStr))
                        myDict.Add(newArrStr, 0);
                    myDict[newArrStr]++;
                }
            }
            return myDict;
        }
    }
}
