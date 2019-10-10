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
            string problemName = args[0];
            string approach = args[1];
            string filterType = args[2];
            string levelToRun = args[3];

            //Set that Pex4Fun.exe runs from as current directory
            string currDir = System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString();
            //Move 4 levels up to set the top directory
            //Go from C:...codesimilarity\Pex4Fun\Sp18_Q11_11_lastTen\behavioralsimilarity\Pex4Fun\bin\Debug\ -> C:...\codesimilarity\
            string topDir = Path.GetFullPath(Path.Combine(currDir, @"..\..\..\..\..\..\"));
            string editedMetaProjectDir = topDir + @"Approach\" + approach + @"\" + problemName + @"\editedMetaProject";
            string allStudentsDir = topDir + @"Students\" + problemName;
            string firstLevelResultsDir = topDir + @"Results\FirstLevel\" + problemName + @"\" + filterType;
            string secondLevelResultsDir = topDir + @"Results\SecondLevel\Approach\CompleteEquivalence\" + problemName + @"\" + filterType;
            string secondLevelResultsDirAlt = topDir + @"Results\SecondLevel\Approach\NewEquivalence\" + problemName + @"\" + filterType;
            string subsumptionResultsDir = topDir + @"Results\SecondLevel\Approach\Subsumption\" + problemName;
            string assemblyName = "meta_project1525456207";
            string hardcodedMetaProjName = "meta_project1525456207";
            string methodName = "LastTen";
            Random randNum = new Random();
            //Dictionary key maps to List -> List -> string arrays...lets me have mult. vals. map to single key
            Dictionary<double, List<List<string[]>>> scoreToTestBodyMap = new Dictionary<double, List<List<string[]>>>();

            /* Cluster level one */
            if (levelToRun.ToLower() == "first" || levelToRun.ToLower() == "both")
            {
                //Choose each folder that ends in "@illinois.edu"
                foreach (var studentDir in Directory.GetDirectories(allStudentsDir))
                {
                    if (studentDir.Contains("@illinois.edu"))
                    {
                        foreach (var file in Directory.GetFiles(studentDir))
                        {
                            if (file.EndsWith(".cs"))
                            {
                                //Below false IFF empty lastTen method body
                                if (FileModifier.CopyBodyToMetaProgram(file, editedMetaProjectDir, methodName, hardcodedMetaProjName))
                                {
                                    //Account for default / non-default Pex emission filter
                                    changeFilterType(filterType, editedMetaProjectDir + @"\MetaProgram.cs");
                                    if (BuildDirectory.BuildSingleProject(editedMetaProjectDir, true))
                                    {
                                        //Below line ensures that Pex4Fun uses most updated ver. of asembly file
                                        copyOverAssemblyFile(editedMetaProjectDir, currDir, assemblyName);

                                        string fileName = file.Substring(file.LastIndexOf("\\") + 1);
                                        //12/03/18, by Jonathan: Method to run pex on editedMetaProject's MetaProgram.cs
                                        RunPex.RunPexOnEditedMetaProject(editedMetaProjectDir, assemblyName);
                                        string fileNameMinusCS = fileName.Substring(0, fileName.Length - 3);
                                        Tuple<List<string[]>, List<string[]>, string> passedAndFailedTests = ExtractPexResults.ExtractTestsForEditedMetaProject(editedMetaProjectDir, fileNameMinusCS, "MetaProgram", "Check", assemblyName);
                                        List<string[]> passedTests = passedAndFailedTests.Item1;
                                        List<string[]> failedTests = passedAndFailedTests.Item2;
                                        //Round score to nearest hundreth
                                        double score = Math.Round(scoreFromPexTestsXML(editedMetaProjectDir, fileNameMinusCS), 2);

                                        //string moveFileToClusterFileName = fileName;
                                        string moveFileToClusterScore = score.ToString();
                                        string recordPassedMethodBodyFilename = score.ToString();
                                        bool areTestsIdentical = false;

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
                                                        string randNumStr = randNum.Next(0, 100).ToString();
                                                        moveFileToClusterScore = score.ToString() + "_" + randNumStr;
                                                        recordPassedMethodBodyFilename = score.ToString() + @"\" + randNumStr;
                                                    }
                                                }
                                            }
                                            //Else if the key didn't already exist in Dictionary...
                                            //...Store the list in memory IFF tests are NOT identical...
                                            if (!areTestsIdentical)
                                            {
                                                scoreToTestBodyMap.Add(score, new List<List<string[]>>());
                                                scoreToTestBodyMap[score].Add(passedTests);
                                            }
                                            //...Store list in file
                                            recordPassedAndFailedMethodBodies(passedTests, failedTests, firstLevelResultsDir,
                                                recordPassedMethodBodyFilename);
                                        }
                                        moveFileToCluster(moveFileToClusterScore, firstLevelResultsDir, file, fileName);
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
                }
            }







            /* Cluster level 2 */
            if (approach.ToLower() != "subsumption" && (levelToRun.ToLower() == "second" || levelToRun.ToLower() == "both"))
            {
                //Skip the PSE = 1 and PSE = NaN folders
                foreach (var pseScoreFolder in Directory.GetDirectories(firstLevelResultsDir))
                {
                    if (pseScoreFolder.Substring(pseScoreFolder.LastIndexOf("\\") + 1) == "1"
                        || pseScoreFolder.Contains("NaN") || pseScoreFolder.Contains("Passed&FailedTests"))
                    {
                        continue;
                    }
                    int solutionFileIndex = 0;
                    string[] filesList = Directory.GetFiles(pseScoreFolder);
                    foreach (var solutionFile in filesList)
                    {
                        string solutionFileName = solutionFile.Substring(solutionFile.LastIndexOf("\\") + 1);

                        if (solutionFile.EndsWith(".cs"))
                        {
                            //Establish the current file as the ref soln
                            if (FileModifier.replaceSolutionMethodBody(methodName, solutionFile, editedMetaProjectDir + @"\MetaProgram.cs"))
                            {

                                int fileCount = Directory.GetFiles(pseScoreFolder).Length;
                                int submissionFileIndex = 0;
                                //Pair-wise comparison on each file
                                foreach (var submissionFile in filesList)
                                {
                                    if (submissionFile.EndsWith(".cs"))
                                    {
                                        string submissionFileName = submissionFile.Substring(submissionFile.LastIndexOf("\\") + 1);
                                        string pseScoreFolderName = pseScoreFolder.Substring(pseScoreFolder.LastIndexOf('\\') + 1);
                                        if (fileCount == 1)
                                        {
                                            recordLevelTwoResult(pseScoreFolder, "PSE Cluster: " + pseScoreFolderName
                                                + "\tReference Submission: " + submissionFileName + "\tMatched");
                                        }
                                        else if (submissionFileIndex > solutionFileIndex)
                                        {
                                            //Begin replacing method body of submission
                                            //Return false if unsuccessful copy (empty method body)
                                            if (FileModifier.CopyBodyToMetaProgram(submissionFile, editedMetaProjectDir, methodName, hardcodedMetaProjName))
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
                                                    Tuple<List<string[]>, List<string[]>, string> extractedResults = ExtractPexResults.ExtractTestsForEditedMetaProject(editedMetaProjectDir, combinedFileName, "MetaProgram", "Check", assemblyName);
                                                    //string failType = extractedResults.Item3;
                                                    //if failType == "assert"... else if failType == "exception"...

                                                    //Round score to nearest hundreth
                                                    double score = Math.Round(scoreFromPexTestsXML(editedMetaProjectDir, combinedFileName), 2);
                                                    if (score == 1)
                                                    {
                                                        recordLevelTwoResult(pseScoreFolder, "PSE Cluster: " + pseScoreFolderName
                                                            + "\tResultant PSE Score: " + score
                                                            + "\tReference Submission: " + solutionFileName
                                                            + "\tCompared Submission: " + submissionFileName
                                                            + "\tMatched");
                                                        //Remove submissionFile from filesList if score == 1 (more efficient pairwise algorithm)
                                                        filesList = filesList.Where(w => w != filesList[submissionFileIndex]).ToArray();
                                                        submissionFileIndex--; //Decrem then increm submissionFileIndex to keep value the same
                                                    }
                                                    else
                                                    {
                                                        recordLevelTwoResult(pseScoreFolder, "PSE Cluster: " + pseScoreFolderName
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
                                    submissionFileIndex++;
                                }
                            }
                        }
                        solutionFileIndex++;
                    }
                }
            }

            /* Level 2: Subsumption */
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
                            if (FileModifier.replaceSolutionMethodBody(methodName, solutionFile, editedMetaProjectDir + @"\MetaProgram.cs"))
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
                                    if (FileModifier.CopyBodyToMetaProgram(submissionFile, editedMetaProjectDir, methodName, hardcodedMetaProjName))
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
                                            Tuple<List<string[]>, List<string[]>, string> extractedResults = ExtractPexResults.ExtractTestsForEditedMetaProject(editedMetaProjectDir, combinedFileName, "MetaProgram", "Check", assemblyName);
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

        public static void moveFileToCluster(string score, string firstLevelResultsDir, string submissionFilePathSrc, string fileName)
        {
            string clusterDirectory = firstLevelResultsDir + @"\" + score;

            //Create directory if it doesn't already exist
            if (!Directory.Exists(clusterDirectory))
            {
                Directory.CreateDirectory(clusterDirectory);
            }
            string destFilePath = System.IO.Path.Combine(clusterDirectory, fileName);
            System.IO.File.Copy(submissionFilePathSrc, destFilePath, true);
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

        public static void recordLevelTwoResult(string pseScoreFolder, string stringToPrint)
        {
            string path = pseScoreFolder + @"\SecondClusterResults.txt";
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

        public static void recordPassedAndFailedMethodBodies(List<string[]> passedTests, List<string[]> failedTestsm, string firstLevelResultsDir, string score)
        {
            //Record passing:
            System.IO.FileInfo file = new System.IO.FileInfo(firstLevelResultsDir + @"\Passed&FailedTests\Passed\" + score + ".txt");
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            foreach (var testBody in passedTests)
            {
                System.IO.File.AppendAllLines(file.FullName, testBody);
            }

            //Record failing:
            file = new System.IO.FileInfo(firstLevelResultsDir + @"\Passed&FailedTests\Failed\" + score + ".txt");
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            foreach (var testBody in passedTests)
            {
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

            string[] submissionFileText = File.ReadAllLines(metaProgramFilePath);
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
    }
}
