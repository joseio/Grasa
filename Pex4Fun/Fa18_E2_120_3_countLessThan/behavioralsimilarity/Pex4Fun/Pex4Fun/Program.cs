using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Pex4Fun
{
    public class Program
    {
        //GENERAL NOTES (12/19/18):
        // 1. MUST run Program.cs W/O debugging (Toolbar -> Debug -> Start w/o Debugging)
        // 2. CANNOT have the ...\editedMetaProject\bin\Debug\reports folder open

        public static void Main(string[] args)
        {
            string problemName = null, approach = "First", filterType = null, levelToRun = null;
            if (args.Length == 4)
            {
                problemName = args[0];
                approach = args[1];
                filterType = args[2];
                levelToRun = args[3];
            }
            else if (args.Length == 3)
            {
                problemName = args[0];
                filterType = args[1];
                levelToRun = args[2];
            }

            //Set that Pex4Fun.exe runs from as current directory
            string currDir = System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString();
            //Move 4 levels up to set the top directory
            //Go from C:...codesimilarity\Pex4Fun\Fa18_E2_120_3_countLessThan\behavioralsimilarity\Pex4Fun\bin\Debug\ -> C:...\codesimilarity\
            string topDir = Path.GetFullPath(Path.Combine(currDir, @"..\..\..\..\..\..\"));
            string editedMetaProjectDir = topDir + @"Approach\" + approach + @"\" + problemName + @"\editedMetaProject";
            string allStudentsDir = topDir + @"Students\" + problemName;
            string firstLevelResultsDir = topDir + @"Results\FirstLevel\" + problemName + @"\" + filterType;
            string secondLevelResultsDir = topDir + @"Results\SecondLevel\Approach\CompleteEquivalence\" + problemName + @"\" + filterType;
            string secondLevelResultsDirAlt = topDir + @"Results\SecondLevel\Approach\NewEquivalence\" + problemName + @"\" + filterType;
            string subsumptionResultsDir = topDir + @"Results\SecondLevel\Approach\Subsumption\" + problemName;
            string assemblyName = "meta_project1525456207";
            string hardcodedMetaProjName = "meta_project1525456207";
            string instructorSolnDir = topDir + @"InstructorSolutions\" + problemName + ".cs";
            string className = "BinaryTree";
            Random randNum = new Random();
            Dictionary<double, HashSet<string>> uniquePassingTestsClusterMap = new Dictionary<double, HashSet<string>>();
            Dictionary<double, HashSet<string>> uniqueFailingTestsClusterMap = new Dictionary<double, HashSet<string>>();


            //Dictionary key maps to List -> List -> string arrays...lets me have mult. vals. map to single key
            Dictionary<double, List<List<string[]>>> scoreToTestBodyMap = new Dictionary<double, List<List<string[]>>>();


            /* Cluster level one */
            if (levelToRun.ToLower() == "first" || levelToRun.ToLower() == "both")
            {
                string[] allStudentDirs_binaryTree = Directory.GetDirectories(allStudentsDir);
                //Get all files across allStudentDirs
                var filesArr = Directory.EnumerateDirectories(allStudentsDir).SelectMany(directory
                    => Directory.EnumerateFiles(directory, "*.cs"));
                //Conv arr -> List for easier manipulation
                List<string> filesList = new List<string>(filesArr);
                for (int i = 0; i < filesList.Count; i+=2) //Iterate by two b/c each folder has two files
                {
                    string binaryTreeFile = filesList[i];
                    string yourBinaryTreeFile = filesList[i+1];
                    if (yourBinaryTreeFile.EndsWith(".cs"))
                    {
                        //Below false IFF empty addToEnd method body
                        if (FileModifier.CopyBodyToMetaProgram(binaryTreeFile, yourBinaryTreeFile, editedMetaProjectDir, className, hardcodedMetaProjName))
                        {
                            //Account for default / non-default Pex emission filter
                            changeFilterType(filterType, editedMetaProjectDir + @"\MetaProgram.cs");
                            if (BuildDirectory.BuildSingleProject(editedMetaProjectDir, true))
                            {
                                //Below line ensures that Pex4Fun uses most updated ver. of asembly file
                                copyOverAssemblyFile(editedMetaProjectDir, currDir, assemblyName);

                                string fileName = yourBinaryTreeFile.Substring(yourBinaryTreeFile.LastIndexOf("\\") + 1);
                                int lastIdx = yourBinaryTreeFile.LastIndexOf('\\');
                                string tmp = yourBinaryTreeFile.Substring(0, lastIdx);
                                string fileDirName = tmp.Substring(tmp.LastIndexOf('\\') + 1);

                                //12/03/18, by Jonathan: Method to run pex on editedMetaProject's MetaProgram.cs
                                RunPex.RunPexOnEditedMetaProject(editedMetaProjectDir, assemblyName);
                                Tuple<HashSet<string[]>, HashSet<string[]>, string> passedAndFailedTests = ExtractPexResults.ExtractTestsForEditedMetaProject(editedMetaProjectDir, fileDirName, "MetaProgram", "Check", assemblyName);
                                HashSet<string[]> passedTests = passedAndFailedTests.Item1;
                                HashSet<string[]> failedTests = passedAndFailedTests.Item2;
                                //Round score to nearest hundreth
                                double score = Math.Round(scoreFromPexTestsXML(editedMetaProjectDir, fileDirName), 2);

                                //string moveFileToClusterFileName = fileName;
                                string moveFileToClusterScore = score.ToString();
                                string recordPassedMethodBodyFilename = score.ToString();
                                bool areTestsIdentical = false;
                                int clusterNum = 1;

                                //If there were 1+ passing tests...
                                if (passedTests.Count != 0)
                                {
                                    List<List<string[]>> existantTestBodiesList = new List<List<string[]>>();
                                    //FIRST check if key already exists in Dictionary before adding...
                                    if (scoreToTestBodyMap.TryGetValue(score, out existantTestBodiesList))
                                    {
                                        //Check if both lists passed on SAME tests, regardless of order / dupe entries
                                        var list1Lookup = new HashSet<string[]>(passedTests);
                                        foreach (var methodBodies in existantTestBodiesList)
                                        {
                                            var list2Lookup = new HashSet<string[]>(methodBodies);
                                            if (list1Lookup.SetEquals(list2Lookup))
                                            {
                                                //If they've got same values, then they truly belong in same parent cluster
                                                recordPassedMethodBodyFilename = score.ToString();
                                                moveFileToClusterScore = score.ToString();
                                                areTestsIdentical = true;
                                                break;
                                            }
                                            else
                                            {
                                                //Else they belong in same parent cluster, but DIFF child clusters
                                                clusterNum++;
                                                moveFileToClusterScore = score.ToString() + @"\" + score.ToString() + "_" + clusterNum.ToString();
                                                recordPassedMethodBodyFilename = score.ToString() + @"\" + clusterNum.ToString();
                                            }
                                        }
                                    }
                                    //Else if the key didn't already exist in Dictionary...
                                    //...Store the list in memory IFF tests are NOT identical...
                                    if (!areTestsIdentical)
                                    {
                                        //If already contains 'score' key, just append the test to it!
                                        if (!scoreToTestBodyMap.ContainsKey(score))
                                            scoreToTestBodyMap.Add(score, new List<List<string[]>>());
                                        scoreToTestBodyMap[score].Add(passedTests.ToList());
                                    }
                                    //...Store list in file
                                    recordPassedAndFailedMethodBodies(fileDirName, passedTests, failedTests, firstLevelResultsDir,
                                        recordPassedMethodBodyFilename);
                                }
                                moveDirToCluster(moveFileToClusterScore, firstLevelResultsDir, allStudentDirs_binaryTree[i], fileName);
                                //recordLevelOneResult(score, studentDir, fileName);
                            }
                        }
                        //MetaProgram.cs didn't build
                        else
                        {
                            //moveSubmissionToUnsuccessful(studentDir, file, null);
                        }
                    }
                }
            }







            /* Cluster level 2 */
            /*
            if (approach.ToLower() != "subsumption" && (levelToRun.ToLower() == "second" || levelToRun.ToLower() == "both"))
            {
                Dictionary<string, double> submissionScoreMap = new Dictionary<string, double>();
                string[] allStudentDirs_partition = Directory.GetDirectories(allStudentsDir);
                //Get all files across allStudentDirs
                var filesArr = Directory.EnumerateDirectories(allStudentsDir).SelectMany(directory
                    => Directory.EnumerateFiles(directory, "*.cs"));

                //Conv arr -> List for easier manipulation
                List<string> filesList = new List<string>(filesArr);

                //Insert instructor correct solution at beginning of list (first pass = comparison to ACTUAL soln)
                filesList.Insert(0, instructorSolnDir);
                for (int i = 0; i < filesList.Count - 1; i++)
                {
                    string solutionFile = filesList[i];
                    string solutionFileName = solutionFile.Substring(solutionFile.LastIndexOf("\\") + 1);

                    if (solutionFile.EndsWith(".cs"))
                    {
                        //Establish the current file as the ref soln (SubmissionB)
                        if (FileModifier.replaceSolutionMethodBody(className, solutionFile, editedMetaProjectDir + @"\MetaProgram.cs"))
                        {
                            int fileCount = filesArr.Count();
                            //Pair-wise comparison on each file
                            for (int j = i + 1; j < filesList.Count; j++)
                            {
                                string submissionFile = filesList[j];
                                if (submissionFile.EndsWith(".cs"))
                                {
                                    string submissionFileName = submissionFile.Substring(submissionFile.LastIndexOf("\\") + 1);
                                    int lastIndx = submissionFile.LastIndexOf('\\');
                                    string temp = submissionFile.Substring(0, lastIndx);
                                    string submissionDirName = temp.Substring(temp.LastIndexOf('\\') + 1);

                                    lastIndx = filesList[i].LastIndexOf('\\');
                                    temp = filesList[i].Substring(0, lastIndx);
                                    string solutionDirName = temp.Substring(temp.LastIndexOf('\\') + 1);

                                    if (fileCount == 1)
                                    {
                                        recordLevelTwoResult(submissionDirName, "Cluster: " + solutionDirName
                                            + "\tReference Submission: " + submissionFileName + "\tMatched");
                                    }
                                    else
                                    {
                                        //Establish submissionA
                                        //Return false if unsuccessful copy (empty method body)
                                        if (FileModifier.CopyBodyToMetaProgram(submissionFile, editedMetaProjectDir, className, hardcodedMetaProjName))
                                        {
                                            //If compiled correctly after having replaced the body
                                            changeFilterType(filterType, editedMetaProjectDir + @"\MetaProgram.cs");
                                            if (BuildDirectory.BuildSingleProject(editedMetaProjectDir, true))
                                            {
                                                //Below line ensures that Pex4Fun uses most updated ver. of asembly file
                                                copyOverAssemblyFile(editedMetaProjectDir, currDir, assemblyName);

                                                RunPex.RunPexOnEditedMetaProject(editedMetaProjectDir, assemblyName);
                                                //string submissionFileNameMinusCS = submissionFileName.Substring(0, submissionFileName.Length - 3);
                                                //string solutionFileNameMinusCS = solutionFileName.Substring(0, solutionFileName.Length - 3);
                                                string combinedFileName = submissionDirName + "&" + solutionDirName;
                                                Tuple<HashSet<string[]>, HashSet<string[]>, string> extractedResults = ExtractPexResults.ExtractTestsForEditedMetaProject(editedMetaProjectDir, combinedFileName, "MetaProgram", "Check", assemblyName);
                                                //Item1 = passedTests, Item2 = failedTests

                                                //string failType = extractedResults.Item3;
                                                //if failType == "assert"... else if failType == "exception"...

                                                //Round score to nearest hundreth
                                                double score = Math.Round(scoreFromPexTestsXML(editedMetaProjectDir, combinedFileName), 2);
                                                recordPassedAndFailedMethodBodies(combinedFileName, extractedResults.Item1, extractedResults.Item2, secondLevelResultsDir, score.ToString());


                                                //TODO:     
                                                // Use FIRST pass score to figure out what initial cluster to assign folks to, THEN use 1/0 to figure out whether submissions should be clustered together
                                                //First pass, add all scores to the 

                                                //Create mapping of PSE scores assigned during first pass
                                                if (i == 0)
                                                {
                                                    //Add unique passing tests to map
                                                    if (!uniquePassingTestsClusterMap.ContainsKey(score))
                                                        uniquePassingTestsClusterMap.Add(score, new HashSet<string>());
                                                    //Conv string[] -> string, preserving "\n" 
                                                    uniquePassingTestsClusterMap[score].Add(string.Join("", extractedResults.Item1.Select(x => string.Join("", x))));

                                                    //Add unique failing tests to map
                                                    if (!uniqueFailingTestsClusterMap.ContainsKey(score))
                                                        uniqueFailingTestsClusterMap.Add(score, new HashSet<string>());
                                                    //Conv string[] -> string
                                                    uniqueFailingTestsClusterMap[score].Add(string.Join("", extractedResults.Item2.Select(x => string.Join("", x))));

                                                    //Add solution name and score to map
                                                    if (!submissionScoreMap.ContainsKey(solutionFileName))
                                                        submissionScoreMap.Add(solutionFileName, score);
                                                    submissionScoreMap[solutionFileName] = score;

                                                    //Add submission name and score to map
                                                    if (!submissionScoreMap.ContainsKey(submissionFileName))
                                                        submissionScoreMap.Add(submissionFileName, score);
                                                    submissionScoreMap[submissionFileName] = score;
                                                }

                                                if (score == 1)
                                                {
                                                    recordLevelTwoResult(submissionDirName, "Cluster: " + solutionDirName
                                                        + "\tResultant PSE Score: " + score
                                                        + "\tReference Submission: " + solutionFileName
                                                        + "\tCompared Submission: " + submissionFileName
                                                        + "\tMatched");

                                                    //Add tests pertaining to PSE score assigned during first pass here:
                                                    if (i != 0)
                                                        score = submissionScoreMap[submissionFileName];
                                                    //Add unique passing tests to map
                                                    if (!uniquePassingTestsClusterMap.ContainsKey(score))
                                                        uniquePassingTestsClusterMap.Add(score, new HashSet<string>());
                                                    //Conv string[] -> string, preserving "\n" 
                                                    uniquePassingTestsClusterMap[score].Add(string.Join("", extractedResults.Item1.Select(x => string.Join("", x))));

                                                    //Add unique failing tests to map
                                                    if (!uniqueFailingTestsClusterMap.ContainsKey(score))
                                                        uniqueFailingTestsClusterMap.Add(score, new HashSet<string>());
                                                    uniqueFailingTestsClusterMap[score].Add(string.Join("", extractedResults.Item2.Select(x => string.Join("", x))));

                                                    //Cluster those that got matched and remove them from filesList
                                                    filesList.RemoveAt(j);
                                                    j--; //Keep inner ptr in same place after removal
                                                    Console.WriteLine(filesList[j]);
                                                }
                                                else
                                                {
                                                    recordLevelTwoResult(submissionDirName, "Cluster: " + solutionDirName
                                                        + "\tResultant PSE Score: " + score
                                                        + "\tReference Submission: " + solutionFileName
                                                        + "\tCompared Submission: " + submissionFileName
                                                        + "\tNot Matched");
                                                }

                                            }

                                        }
                                        //MetaProgram.cs didn't build
                                        else
                                        {
                                            //moveSubmissionToUnsuccessful(pseScoreFolder, solutionFileName, submissionFileName);
                                            Console.WriteLine(solutionFileName + " and " + submissionFileName + " failed to produce compiling editedMetaProject");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }//End level 2
            */





            //TODO: Keep one test as the reference. Loop over all other tests and call the Except() to figure out the distinct set of tests that the reference has
            //Q from Angello: How to ensure that the unique, minimal test set we're generating per cluster PASSES on every other cluster but fails its own cluster??
            foreach (var reference in uniquePassingTestsClusterMap)
            {
                //Initialize IEnumerable<string> as the first test in dict
                var currTest = uniquePassingTestsClusterMap[reference.Key].Intersect(uniquePassingTestsClusterMap[reference.Key]);
                foreach (var other in uniquePassingTestsClusterMap)
                {
                    if (reference.Key == other.Key)
                        continue;
                    //After looping done, currTest is the MIN set of passing tests to differentiate cluster from others
                    currTest = currTest.Intersect(uniquePassingTestsClusterMap[reference.Key]
                        .Except(uniquePassingTestsClusterMap[other.Key]));
                }
                recordUniquePassFailClusterTests(currTest, reference.Key, secondLevelResultsDir, "Passed");
            }


            foreach (var reference in uniqueFailingTestsClusterMap)
            {
                var currTest = uniqueFailingTestsClusterMap[reference.Key].Intersect(uniqueFailingTestsClusterMap[reference.Key]);
                foreach (var other in uniqueFailingTestsClusterMap)
                {
                    if (reference.Key == other.Key)
                        continue;
                    //After looping done, currTest is the MIN set of failing tests to differentiate cluster from others
                    currTest = currTest.Intersect(uniqueFailingTestsClusterMap[reference.Key]
                        .Except(uniqueFailingTestsClusterMap[other.Key]));
                }
                recordUniquePassFailClusterTests(currTest, reference.Key, secondLevelResultsDir, "Failed");
            }









            /* Level 2: Subsumption */
            /*
            if (approach.ToLower() == "subsumption")
            {
                string chosenDir = secondLevelResultsDir;
                if (!Directory.Exists(secondLevelResultsDir))
                    chosenDir = secondLevelResultsDirAlt; //Choose alternate secondLevelDir if orig. doesn't exist!

                foreach (var pseScoreFolder in Directory.GetDirectories(chosenDir))
                {
                    Console.WriteLine("Evaluating PSE FOLDER: " + pseScoreFolder.Substring(pseScoreFolder.LastIndexOf("\\") + 1));
                    string[] allChildClusters = Directory.GetDirectories(pseScoreFolder);
                    for (int i = 0; i < allChildClusters.Length - 1; i++)
                    {
                        string currChild = allChildClusters[i];
                        //Skip the PSE = 1 and PSE = NaN folders
                        if (currChild.Substring(currChild.LastIndexOf("\\") + 1) == "1"
                            || currChild.Contains("NaN"))
                        {
                            continue;
                        }
                        string[] solutionFilesList = Directory.GetFiles(currChild); //Get all files within currChild
                        Random r = new Random();
                        int randIndx = r.Next(0, solutionFilesList.Length); //[0, filesList.Length)
                        string solutionFile = solutionFilesList[randIndx]; //Ref Soln = rand file inside child
                        string solutionFileName = solutionFile.Substring(solutionFile.LastIndexOf("\\") + 1);

                        if (solutionFile.EndsWith(".cs"))
                        {
                            //Establish the current file as the ref soln
                            if (FileModifier.replaceSolutionMethodBody(className, solutionFile, editedMetaProjectDir + @"\MetaProgram.cs"))
                            {
                                string nextChild = allChildClusters[i + 1]; //Get next child
                                if (nextChild.Substring(nextChild.LastIndexOf("\\") + 1) == "1"
                                    || nextChild.Contains("NaN"))
                                {
                                    continue;
                                }
                                string[] submissionFilesList = Directory.GetFiles(nextChild); //Get all files within nextChild
                                randIndx = r.Next(0, submissionFilesList.Length); //[0, filesList.Length)
                                string submissionFile = submissionFilesList[randIndx]; //Ref Soln = rand file inside child
                                string submissionFileName = submissionFile.Substring(submissionFile.LastIndexOf("\\") + 1);


                                if (submissionFile.EndsWith(".cs"))
                                {
                                    Console.WriteLine("Both " + solutionFileName + " and " + submissionFileName + " end in .cs");

                                    //Begin replacing method body of submission
                                    //Return false if unsuccessful copy (empty method body)
                                    if (FileModifier.CopyBodyToMetaProgram(submissionFile, editedMetaProjectDir, className, hardcodedMetaProjName))
                                    {
                                        //If compiled correctly after having replaced the body
                                        changeFilterType(filterType, editedMetaProjectDir + @"\MetaProgram.cs");
                                        if (BuildDirectory.BuildSingleProject(editedMetaProjectDir, true))
                                        {
                                            //Below line ensures that Pex4Fun uses most updated ver. of asembly file
                                            copyOverAssemblyFile(editedMetaProjectDir, currDir, assemblyName);

                                            RunPex.RunPexOnEditedMetaProject(editedMetaProjectDir, assemblyName);
                                            string submissionFileNameMinusCS = submissionFileName.Substring(0, submissionFileName.Length - 3);
                                            string solutionFileNameMinusCS = solutionFileName.Substring(0, solutionFileName.Length - 3);
                                            string combinedFileName = solutionFileNameMinusCS + "&" + submissionFileNameMinusCS;
                                            Tuple<HashSet<string[]>, HashSet<string[]>, string> extractedResults = ExtractPexResults.ExtractTestsForEditedMetaProject(editedMetaProjectDir, combinedFileName, "MetaProgram", "Check", assemblyName);
                                            string failType = extractedResults.Item3;

                                            string message = "";
                                            if (failType == "assertion")
                                            {
                                                Console.WriteLine("s2 >= s1");
                                                message = "Reference solution subsumes student submission.";
                                            }
                                            else if (failType == "exception")
                                            {
                                                Console.WriteLine("s1 >= s2");
                                                message = "Student submission subsumes reference solution.";
                                            }
                                            else if (failType == "")
                                            {
                                                message = "No subsumption.";
                                            }
                                            else
                                            {
                                                message = "Neither...something likely went wrong.";
                                            }

                                            //Record to file in subsumption folder
                                            recordSubsumptionResult(subsumptionResultsDir, combinedFileName, message);
                                        }
                                        //MetaProgram.cs didn't build
                                        else
                                        {
                                            //moveSubmissionToUnsuccessful(pseScoreFolder, solutionFileName, submissionFileName);
                                            Console.WriteLine(solutionFileName + " and " + submissionFileName + " failed to produce compiling editedMetaProject");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            */









        } //End Main()





        private static void moveSubmissionToUnsuccessful(string path, string solutionFileName, string submissionFileName)
        {
            string textFilePath = path + @"\UnsuccessfullyBuiltFiles.txt";
            if (!File.Exists(textFilePath))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(textFilePath))
                {
                    if (submissionFileName == null)
                    {
                        tw.WriteLine(solutionFileName + " had build error");
                    }
                    else
                    {
                        tw.WriteLine("Either " + solutionFileName + " or " + submissionFileName + " yielded build error");
                    }
                }
            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(textFilePath, true))
                {
                    if (submissionFileName == null)
                    {
                        tw.WriteLine(solutionFileName + " had build error");
                    }
                    else
                    {
                        tw.WriteLine("Either " + solutionFileName + " or " + submissionFileName + " yielded build error");
                    }
                }
            }
        }


        public static string[] returnJustMethodBody(string[] passedTests)
        {
            string methodSignature = "public void";
            StringBuilder sb = new StringBuilder();
            bool copy = false;
            foreach (string line in passedTests)
            {
                if (line.Contains(methodSignature))
                {
                    copy = true;
                    //sb.AppendLine(line);
                }
                else if (copy)
                {
                    if (line.Contains("}"))
                    {
                        copy = false;
                    }
                    //Don't copy empty lines
                    if (line != "")
                    {
                        if (line.Contains("MetaProgram.Check"))
                        {
                            sb.AppendLine(line);
                            continue;
                        }
                        sb.AppendLine(line);
                    }
                }
            }

            string[] methodBody = sb.ToString().Split(Environment.NewLine.ToCharArray()).ToArray();
            //Remove empty lines
            methodBody = methodBody.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return methodBody;
        }



        public static double scoreFromPexTestsXML(string editedMetaProjDir, string submissionFileName)
        {
            List<Test> tests = Serializer.DeserializeTests(editedMetaProjDir + @"\PexTests\" + submissionFileName
                + "_PexTests.xml");
            double numTotalTests = tests.Count;

            double numPassedTests = 0;
            foreach (var test in tests)
            {
                if (test.Result.ToString().Equals("Passed"))
                {
                    numPassedTests++;
                }
            }

            Console.WriteLine("Submission: " + submissionFileName + ", #Passed: " + numPassedTests + ", #Total: " + numTotalTests);
            //Console.ReadKey();
            return numPassedTests / numTotalTests;
        }

        public static void moveDirToCluster(string score, string firstLevelResultsDir, string submissionSrcDir, string fileName)
        {
            string clusterDirectory = firstLevelResultsDir + @"\" + score;
            //Create directory if it doesn't already exist
            if (!Directory.Exists(clusterDirectory))
            {
                Directory.CreateDirectory(clusterDirectory);
            }
            string destFilePath = System.IO.Path.Combine(clusterDirectory, submissionSrcDir, fileName);

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(submissionSrcDir, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(submissionSrcDir, destFilePath), true);
        }

        /*public static void recordLevelOneResulst(double score, string studentDir, string fileName)
        {
            string path = studentDir + @"\FirstClusterResults.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine("New run:");
                    if (score.ToString().Equals("NaN"))
                    {
                        tw.WriteLine(fileName + "\t" + "Score: " + score.ToString() + " (Likely infin. execution)");
                    }
                    else 
                    {
                        tw.WriteLine(fileName + "\t" + "Score: " + score.ToString());
                    }
                }
            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path, true))
                {
                    if (score.ToString().Equals("NaN"))
                    {
                        tw.WriteLine(fileName + "\t" + "Score: " + score.ToString() + " (Likely infin. execution)");
                    }
                    else 
                    {
                        tw.WriteLine(fileName + "\t" + "Score: " + score.ToString());
                    }
                }
            }
        } */

        public static void recordLevelTwoResult(string studentDir, string stringToPrint)
        {
            string path = studentDir + @"\SecondClusterResults.txt";
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

        public static void recordPassedAndFailedMethodBodies(String filename, HashSet<string[]> passedTests, HashSet<string[]> failedTests, string firstLevelResultsDir, string score)
        {
            //Record passing:
            System.IO.FileInfo file = new System.IO.FileInfo(firstLevelResultsDir + @"\Passed&FailedTests\Passed\" + score + ".txt");
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            foreach (var testBody in passedTests)
            {
                System.IO.File.AppendAllText(file.FullName, filename + ":\n");
                System.IO.File.AppendAllLines(file.FullName, testBody);
            }

            //Record failing:
            file = new System.IO.FileInfo(firstLevelResultsDir + @"\Passed&FailedTests\Failed\" + score + ".txt");
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            foreach (var testBody in failedTests)
            {
                System.IO.File.AppendAllText(file.FullName, filename + ":\n");
                System.IO.File.AppendAllLines(file.FullName, testBody);
            }
        }

        public static void copyOverAssemblyFile(string editedMetaProjectDir, string currDir, string assemblyFileName)
        {
            string srcBinFile = editedMetaProjectDir + @"\bin\Debug\" + assemblyFileName + ".dll";
            string destBinFile = currDir + @"\Debug\" + assemblyFileName + ".dll";
            try
            {
                System.IO.File.Copy(srcBinFile, destBinFile, true);
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Cannot copy over updated assembly file: currenlty being user by another process");
            }
        }

        public static void changeFilterType(string filterType, string metaProgramFilePath)
        {
            string defaultFilter = "[PexMethod]";
            string emissionFilter = "[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]";

            string filterString = "";
            if (filterType.ToLower() == "defaultfilter")
                filterString = defaultFilter;
            else if (filterType.ToLower() == "emissionfilter")
                filterString = emissionFilter;
            else
            {
                Console.WriteLine("Invalid input. Did you mispell the filter type? Try inputting DefaultFilter or EmissionFilter.");
                Environment.Exit(13); //Invalid input format
            }

            string[] submissionFileText = File.ReadAllLines(metaProgramFilePath);
            //TODO: Add check if file doesn't exist...EXIT program and suggest user to do other filter type

            for (int i = 0; i < submissionFileText.Length; i++)
            {
                if (submissionFileText[i].Contains(defaultFilter) || submissionFileText[i].Contains(emissionFilter))
                {
                    //If already has filter type, clear it and make space for new one
                    submissionFileText[i] = "";
                }

                else if (submissionFileText[i].Contains("public static void Check"))
                {
                    submissionFileText[i - 1] = filterString; //Make line before Check() = the filter
                    break;
                }
            }
            File.WriteAllLines(metaProgramFilePath, submissionFileText);
        }

        public static void recordSubsumptionResult(string subsumptionResultsDir, string combinedFileName, string message)
        {
            //Record subsumption results:
            System.IO.FileInfo file = new System.IO.FileInfo(subsumptionResultsDir + @"\" + combinedFileName + ".txt");
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            System.IO.File.AppendAllText(file.FullName, message);
        }

        public static void recordUniquePassFailClusterTests(IEnumerable<string> test, double score, string secondLevelResultsDir, string resultType)
        {
            //Record resultType (passing / failing test):
            System.IO.FileInfo file = new System.IO.FileInfo(secondLevelResultsDir + @"\MinimalUniqueClusterTests\" + resultType + @"\" + score + ".txt");
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            //System.IO.File.AppendAllText(file.FullName, string.Join("", test));
            foreach (var line in test)
            {
                System.IO.File.AppendAllText(file.FullName, line + "\n");
            }
        }
    }
}
