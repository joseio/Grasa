﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Pex4Fun
{
    public class FileModifier
    {
        public static void AddNameSpace(string newFile, string nameSpace)
        {
            //string[] lines = File.ReadAllLines(newFile);
            //StringBuilder sb = new StringBuilder();
            //bool added = false;
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string line = lines[i].Trim();
            //    string[] tokens = line.Split();
            //    if (tokens[0] == "public")
            //    {
            //        if (!added)
            //        {
            //            sb.AppendLine("namespace " + nameSpace + " {");
            //            added = true;
            //        }
            //    }
            //    else if(tokens[0]=="namespace")
            //    {
            //        throw new Exception("namespace already exists");
            //    }
            //    sb.AppendLine(lines[i]);
            //}
            //sb.AppendLine("}");
            //File.WriteAllText(newFile, sb.ToString());

            string[] lines = File.ReadAllLines(newFile);
            StringBuilder sb = new StringBuilder();
            bool added = false;
            for (int i = 0; i < lines.Length; i++)
            {
                sb.AppendLine(lines[i]);
                string line = lines[i].Trim();
                string[] tokens = line.Split();
                if (!added && tokens[0] == "using")
                {
                    int j = i + 1;
                    while (j < lines.Length)
                    {
                        if (lines[j].Trim() != "" && !lines[j].Trim().StartsWith("using "))
                        {
                            sb.AppendLine("namespace " + nameSpace + " {");
                            added = true;
                        }
                        sb.AppendLine(lines[j]);
                        j++;
                        if (added)
                            break;
                    }
                    i = j - 1;
                    continue;
                }
                if (tokens[0] == "namespace")
                {
                    throw new Exception("namespace already exists");
                }
            }
            sb.AppendLine("}");
            File.WriteAllText(newFile, sb.ToString());
        }

        private static void ChangeClassName(string newFile, string newClassName)
        {
            string[] lines = File.ReadAllLines(newFile);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                string[] tokens = line.Split();
                if (tokens[0] == "public")
                {
                    bool rightClass = false;
                    foreach (var token in tokens)
                    {
                        if (token.Contains("Program"))
                        {
                            rightClass = true;
                            break;
                        }
                    }
                    if (rightClass)
                    {
                        sb.AppendLine("public class Solution");
                        continue;
                    }
                }
                sb.AppendLine(lines[i]);
            }
            File.WriteAllText(newFile, sb.ToString());
        }

        public static void MakeMetaProjects(string topDir, string methodName)
        {
            string[] references = { "Microsoft.Pex.Framework", "Microsoft.Pex.Framework.Settings",
                                  "System.Text.RegularExpressions", "System.Diagnostics"};
            foreach (string taskDir in Directory.GetDirectories(topDir))
            {
                string secretProjectDir = taskDir + "\\secret_project";
                if (!Directory.Exists(secretProjectDir))
                    throw new Exception("Make sure creating the secret project before the meta project");
                string[] files = Directory.GetFiles(taskDir);
                string secretFile = null;
                foreach (var file in files)
                {
                    if (file.EndsWith("solution.cs"))
                    {
                        secretFile = file;
                        break;
                    }
                }
                if (secretFile == null)
                {
                    throw new Exception("secret implementation not found");
                }
                string secretFileName = secretFile.Substring(secretFile.LastIndexOf("\\") + 1);
                string[] compiledFile = new string[3];
                compiledFile[1] = secretFileName;
                compiledFile[2] = "MetaProgram.cs";
                string secretAssembly = secretProjectDir + @"\bin\Debug\secret_project.dll";

                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.EndsWith("secret_project"))
                        continue;
                    foreach (var file in Directory.GetFiles(studentDir))
                    {
                        if (file.EndsWith(".cs"))
                        {
                            string fileName = file.Substring(file.LastIndexOf("\\") + 1);
                            string projectName = "meta_project" + fileName.Substring(0, fileName.Length - 3);
                            string projectDir = studentDir + "\\" + projectName;
                            Directory.CreateDirectory(projectDir);
                            string propertyDir = projectDir + "\\Properties";
                            Directory.CreateDirectory(propertyDir);
                            CreateAssemblyFile(propertyDir + "\\AssemblyInfo.cs", projectName);
                            string newFile = projectDir + "\\" + fileName;
                            File.Copy(file, newFile, true);
                            string newSecretFile = projectDir + "\\" + secretFileName;
                            File.Copy(secretFile, newSecretFile, true);
                            AddNameSpace(newFile, "Submission");
                            AddNameSpace(newSecretFile, "Solution");
                            AddUsingStatements(newFile, references);
                            AddUsingStatements(newSecretFile, references);
                            AddPexAttribute(newFile);
                            AddPexAttribute(newSecretFile);
                            string currDir = System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString();

                            //12/02/18, TODO: Copy MetaProgram.cs from editedMetaProgram, then change method body
                            string editedMetaProgramFile = Path.GetFullPath(Path.Combine(projectDir, @"..\..\..\..\editedMetaProject\MetaProgram.cs"));
                            //File.Copy(editedMetaProgramFile, metaProgramFile, true);
                            replaceSubmissionMethodBody("addToEnd(", file, editedMetaProgramFile);
                            //CreateMetaProgram(metaProgramFile, secretFile, secretAssembly, file, methodName);
                            //AddUsingStatements(metaProgramFile, references);


                            compiledFile[0] = fileName;
                            CreateProjectFile(projectDir + "\\" + projectName + ".csproj", compiledFile);
                        }
                    }
                }
            }
        }

        //Method to replace the method body of the student submission
        private static Boolean replaceSubmissionMethodBody(string methodUnderTest, string submissionFile, string metaProgramFilePath)
        {
            //Goal: copy method body from submission -> metaprogram

            string[] submissionFileText = File.ReadAllLines(submissionFile);
            string[] methodBody = getMethodBody(methodUnderTest, submissionFileText);
            string solutionMethodEndMarker = methodUnderTest + "Solution(";
            int letterCount = 0;
            //Go line-by-line to ensure that each has letters and not empty. 
            foreach (string line in methodBody)
            {
                letterCount += Regex.Matches(line, @"[a-zA-Z]").Count;
            }
            if (letterCount == 0)
            {
                //No letters found => empty addToEnd method body "{}"
                return false; //False = unsuccessful copy
            }
            string[] metaProgramFileText = File.ReadAllLines(metaProgramFilePath);
            bool begin = false, once = true, putEmpty = false, copyMethodBody = false; ;

            StringBuilder sb = new StringBuilder();

            int i = 0;
            foreach (string line in metaProgramFileText)
            {
                if (line.Contains(methodUnderTest + "(") && once && i < methodBody.Length)
                {
                    begin = true;
                    once = false;
                }
                else if (begin && i >= methodBody.Length)
                {
                    begin = false;
                    once = true;
                    putEmpty = true;
                }
                else if (begin)
                {
                    copyMethodBody = true;
                }
                else if (i >= methodBody.Length && once && !line.Contains(solutionMethodEndMarker))
                {
                    putEmpty = true;
                }
                if (i >= methodBody.Length && once && line.Contains(solutionMethodEndMarker))
                {
                    once = false;
                }

                if (putEmpty)
                {
                    //Needed bool b/c can't directly modify the "line" iterator in C#
                    sb.AppendLine("");
                }
                else if (copyMethodBody)
                {
                    sb.AppendLine(methodBody[i]);
                    i++;
                }
                else
                {
                    sb.AppendLine(line);
                }

                putEmpty = false;
                copyMethodBody = false;
            }

            File.WriteAllText(metaProgramFilePath, sb.ToString());
            return true; //True = successful copy
        }

        //Method to replace the method body of the student submission
        public static Boolean replaceSolutionMethodBody(string methodUnderTest, string solutionFile, string metaProgramFilePath)
        {
            //Goal: copy method body from submission -> metaprogram

            string[] solutionFileText = File.ReadAllLines(solutionFile);
            string[] methodBody = getMethodBody(methodUnderTest, solutionFileText);
            methodBody = changeMethodToSolution(methodBody, methodUnderTest);

            int letterCount = 0;
            //Go line-by-line to ensure that each has letters and not empty. 
            foreach (string line in methodBody)
            {
                letterCount += Regex.Matches(line, @"[a-zA-Z]").Count;
            }
            if (letterCount == 0)
            {
                //No letters found => empty addToEnd method body "{}"
                return false; //False = unsuccessful copy
            }
            string[] metaProgramFileText = File.ReadAllLines(metaProgramFilePath);
            bool begin = false, once = true, putEmpty = false, copyMethodBody = false; ;

            StringBuilder sb = new StringBuilder();

            int i = 0;
            string solutionMethodUnderTest = methodUnderTest + "Solution";
            string solutionEndMarker = solutionMethodUnderTest + "ForReal";
            foreach (string line in metaProgramFileText)
            {
                if (line.Contains(solutionMethodUnderTest) && once && i < methodBody.Length)
                {
                    begin = true;
                    once = false;
                }
                else if (begin && i >= methodBody.Length)
                {
                    begin = false;
                    once = true;
                    putEmpty = true;
                }
                else if (begin)
                {
                    copyMethodBody = true;
                }
                else if (i >= methodBody.Length && once && !line.Contains(solutionEndMarker))
                {
                    putEmpty = true;
                }
                if (i >= methodBody.Length && once && line.Contains(solutionEndMarker))
                {
                    once = false;
                }

                if (putEmpty)
                {
                    //Needed bool b/c can't directly modify the "line" iterator in C#
                    sb.AppendLine("");
                }
                else if (copyMethodBody)
                {
                    sb.AppendLine(methodBody[i]);
                    i++;
                }
                else
                {
                    sb.AppendLine(line);
                }

                putEmpty = false;
                copyMethodBody = false;
            }

            File.WriteAllText(metaProgramFilePath, sb.ToString());
            return true; //True = successful copy
        }

        private static string[] changeMethodToSolution(string[] methodBody, string methodUnderTest)
        {
            for (int i = 0; i < methodBody.Length; i++)
            {
                int indx = methodBody[i].LastIndexOf(methodUnderTest);
                if (indx != -1)
                {
                    methodBody[i] = methodBody[i].Insert(indx + methodUnderTest.Length, "Solution");
                }
            }
            return methodBody;
        }

        private static string[] getMethodBody(string methodUnderTest, string[] submissionFileText)
        {
            StringBuilder sb = new StringBuilder();
            bool copy = false, once = true;
            foreach (string line in submissionFileText)
            {
                if (line.Contains(methodUnderTest) && once)
                {
                    copy = true;
                    once = false;
                }
                else if (copy)
                {
                    //Don't copy empty lines
                    if (line != "")
                    {
                        sb.AppendLine(line);
                    }
                }
            }
            //Convert string builder to string array
            string[] methodBody = sb.ToString().Split(Environment.NewLine.ToCharArray()).ToArray();
            //Remove empty lines
            methodBody = methodBody.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            //Remove last curly brace
            methodBody[methodBody.Length - 1] = "";
            //Remove empty lines once more
            methodBody = methodBody.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            //Returned string array still contains first "{".
            return methodBody;
        }

        //12/03/18, by Jonathan:
        //Method to copy the method body of the student's implemented addToEnd() to editedMetaProject's MetaProgram.cs
        public static Boolean CopyBodyToMetaProgram(string file, string editedMetaProjectDir, string methodName, string hardcodedMetaProjName)
        {
            // string fileName = file.Substring(file.LastIndexOf("\\") + 1);
            // string projectName = "meta_project" + fileName.Substring(0, fileName.Length - 3);

            Console.WriteLine("Which File: " + file);
            string editedMetaProjectFile = editedMetaProjectDir + @"\MetaProgram.cs";
            return replaceSubmissionMethodBody(methodName, file, editedMetaProjectFile);
        }

        public static void CreateMetaProgram(string filePath, string secretFilePath, string secretAssembly, string submissionFilePath, string methodName)
        {
            string[] lines = File.ReadAllLines(secretFilePath);
            StringBuilder sb = new StringBuilder();
            string paraList = "";
            string invokeParaList = "";
            bool hasFrameworkAttr = false;
            bool hasSettingAttr = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                string[] tokens = line.Split();
                if (tokens[0] == "using")
                {
                    sb.AppendLine(lines[i]);
                    if (line.Contains("Microsoft.Pex.Framework"))
                    {
                        hasFrameworkAttr = true;
                    }
                    else if (line.Contains("Microsoft.Pex.Framework.Settings"))
                    {
                        hasSettingAttr = true;
                    }
                }
            }
            if (!hasFrameworkAttr)
                sb.AppendLine("using Microsoft.Pex.Framework;");
            if (!hasSettingAttr)
                sb.AppendLine("using Microsoft.Pex.Framework.Settings;");

            Type puzzleType = null;
            MethodInfo puzzle = null;
            Assembly assembly = Assembly.LoadFile(secretAssembly);
            foreach (var type in assembly.GetTypes())
            {
                foreach (var method in type.GetMethods())
                {
                    //TODO: REFACTOR s.t. the method name is supplied in Program.cs (main)!!!!!
                    //if (method.Name == "Puzzle") 
                    if (method.Name == methodName)
                    {
                        puzzleType = type;
                        puzzle = method;
                        break;
                    }
                }
                if (puzzle != null)
                    break;
            }
            var paras = puzzle.GetParameters();
            for (int i = 0; i < paras.Count(); i++)
            {
                string paraType = paras[i].ParameterType.Name;
                switch (paraType)
                {
                    case "Int32":
                        paraList += "int " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    case "String":
                        paraList += "string " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    case "Char":
                        paraList += "char " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    case "Boolean":
                        paraList += "bool " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    case "Byte":
                        paraList += "byte " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    case "Int32[]":
                        paraList += "int[] " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    default:
                        throw new Exception("Unhandled para type: " + paraType);
                }
                if (i != paras.Count() - 1)
                {
                    paraList += ", ";
                    invokeParaList += ", ";
                }
            }
            sb.AppendLine("namespace MetaProject{");
            sb.AppendLine("\t[PexClass(typeof(MetaProgram))]");
            sb.AppendLine("\tpublic class MetaProgram{");
            sb.AppendLine("\t\t[PexMethod(TestEmissionFilter=PexTestEmissionFilter.All)]");
            sb.AppendLine("\t\tpublic static void Check(" + paraList + "){"); //open method Check()

            //Try-catch to "ignore" exception thrown when a submission is evaluated as incorrect by Pex
            sb.AppendLine("\t\t\ttry{");//open try{}
            //TODO: PARAMETERIZE THIS (chane to variable defined in main)
            sb.AppendLine("\t\t\t\tif (" + methodName + "Soln(" + invokeParaList + ") != " +
                methodName + "(" + invokeParaList + ")){"); //open if()

            sb.AppendLine("\t\t\t\t\tthrow new Exception(\"Submission failed\");");
            sb.AppendLine("\t\t\t\t}"); //close if()
            sb.AppendLine("\t\t\t}");//close try{}
            sb.AppendLine("\t\t\tcatch (Exception ex) { }");//catch{}
            sb.AppendLine("\t\t}"); //close method Check()
            sb.AppendLine(GetPuzzleMethod(secretFilePath, methodName, methodName + "Soln"));
            sb.AppendLine(GetPuzzleMethod(submissionFilePath, methodName, methodName));
            sb.AppendLine("\t}");//close class
            sb.AppendLine("}");//close namespace
            File.WriteAllText(filePath, sb.ToString());
        }

        public static string GetPuzzleMethod(string file, string oldMethodName, string newMethodName)
        {
            string method = null;
            string[] lines = File.ReadAllLines(file);
            int start = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (line.StartsWith("public"))
                {
                    string[] tokens = line.Split();
                    if (tokens[0] == "public" && tokens[1] == "class")
                    {
                        start = i + 2; //start after "class x \n{"
                        break;
                    }
                }
            }
            int end = 0;
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                string line = lines[i].Trim();
                if (line == "}")
                {
                    end = i - 1;
                    break;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = start; i <= end; i++)
            {
                //TODO: Replace hardcoded method names w/ variable defined in Program.cs (main)
                if (lines[i].Trim().StartsWith("public ") && lines[i].Contains(oldMethodName))
                {
                    lines[i] = lines[i].Replace(oldMethodName, newMethodName);
                }
                sb.AppendLine(lines[i]);
            }
            method = sb.ToString();
            return method;
        }

        public static void CreateMetaProgram_old(string filePath, string secretFilePath, string secretAssembly)
        {
            string[] lines = File.ReadAllLines(secretFilePath);
            StringBuilder sb = new StringBuilder();
            string paraList = "";
            string invokeParaList = "";
            bool hasFrameworkAttr = false;
            bool hasSettingAttr = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                string[] tokens = line.Split();
                if (tokens[0] == "using")
                {
                    sb.AppendLine(lines[i]);
                    if (line.Contains("Microsoft.Pex.Framework"))
                    {
                        hasFrameworkAttr = true;
                    }
                    else if (line.Contains("Microsoft.Pex.Framework.Settings"))
                    {
                        hasSettingAttr = true;
                    }
                }
                //else if(tokens[0]=="public" && line.Contains("Puzzle"))
                //{
                //    int start=line.IndexOf('(');
                //    int end = line.IndexOf(')');
                //    paraList = line.Substring(start+1, end-start-1).Trim();
                //    break;
                //}
            }
            if (!hasFrameworkAttr)
                sb.AppendLine("using Microsoft.Pex.Framework;");
            if (!hasSettingAttr)
                sb.AppendLine("using Microsoft.Pex.Framework.Settings;");

            Type puzzleType = null;
            MethodInfo puzzle = null;
            //bool a = (secretAssembly == @"D:\csharp4fun\1\secret_project\bin\Debug\secret_project.dll");
            //Assembly assembly = Assembly.LoadFrom(secretAssembly);
            Assembly assembly = Assembly.LoadFile(secretAssembly);
            foreach (var type in assembly.GetTypes())
            {
                foreach (var method in type.GetMethods())
                {
                    if (method.Name == "countDistinct")
                    {
                        puzzleType = type;
                        puzzle = method;
                        break;
                    }
                }
                if (puzzle != null)
                    break;
            }
            var paras = puzzle.GetParameters();
            for (int i = 0; i < paras.Count(); i++)
            {
                string paraType = paras[i].ParameterType.Name;
                switch (paraType)
                {
                    case "Int32":
                        paraList += "int " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    case "String":
                        paraList += "string " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    case "Char":
                        paraList += "char " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    case "Boolean":
                        paraList += "bool " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    case "Byte":
                        paraList += "byte " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    case "Int32[]":
                        paraList += "int[] " + paras[i].Name;
                        invokeParaList += paras[i].Name;
                        break;
                    default:
                        throw new Exception("Unhandled para type: " + paraType);
                }
                if (i != paras.Count() - 1)
                {
                    paraList += ", ";
                    invokeParaList += ", ";
                }
            }
            //if (paraList == "")
            //{
            //    throw new Exception("no argument for the Puzzle method");
            //}
            //List<string> paraNames = new List<string>();
            //int previousComma=-1;
            //for (int i = 0; i < paraList.Length; i++)
            //{
            //    if (paraList[i] == ',')
            //    {
            //        string temp = paraList.Substring(previousComma + 1, i - previousComma-1).Trim();
            //        string[] tokens = temp.Split();
            //        paraNames.Add(tokens[tokens.Length - 1]);
            //        previousComma = i;
            //    }
            //}
            //if (paraNames.Count == 0)
            //{
            //    string[] tokens = paraList.Split();
            //    paraNames.Add(tokens[tokens.Length - 1]);
            //}
            sb.AppendLine("namespace MetaProject{");
            sb.AppendLine("\t[PexClass(typeof(MetaProgram))]");
            sb.AppendLine("\tpublic class MetaProgram{");
            sb.AppendLine("\t\t[PexMethod(TestEmissionFilter=PexTestEmissionFilter.All)]");
            sb.AppendLine("\t\tpublic static void Check(" + paraList + "){");

            //sb.AppendLine("\t\t\tif (Solution.Program.Puzzle("+invokeParaList+") != "+
            //    "Submission.Program.Puzzle("+invokeParaList+")){");
            sb.AppendLine("\t\t\tif (Solution." + puzzleType.Name + ".countDistinct(" + invokeParaList + ") != " +
                "Submission." + puzzleType.Name + ".countDistinct(" + invokeParaList + ")){");
            sb.AppendLine("\t\t\t\tthrow new Exception(\"Submission failed\");");
            sb.AppendLine("\t\t\t}");
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            File.WriteAllText(filePath, sb.ToString());
        }

        public static int MakeProjects(string topDir, string methodName)
        {
            int i = 0;
            string[] references = { "Microsoft.Pex.Framework", "Microsoft.Pex.Framework.Settings", 
                                      "System.Text.RegularExpressions" };
            foreach (string taskDir in Directory.GetDirectories(topDir))
            {
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.EndsWith("secret_project"))
                        continue;
                    foreach (var file in Directory.GetFiles(studentDir))
                    {
                        if (file.EndsWith(".cs"))
                        {
                            string fileName = file.Substring(file.LastIndexOf("\\") + 1);
                            string projectName = "project" + fileName.Substring(0, fileName.Length - 3);
                            string projectDir = studentDir + "\\" + projectName;
                            Directory.CreateDirectory(projectDir);
                            CreateProjectFile(projectDir + "\\" + projectName + ".csproj", fileName);
                            string propertyDir = projectDir + "\\Properties";
                            Directory.CreateDirectory(propertyDir);
                            CreateAssemblyFile(propertyDir + "\\AssemblyInfo.cs", projectName);
                            string newFile = projectDir + "\\" + fileName;
                            File.Copy(file, newFile, true);
                            AddNameSpace(newFile, "Submission");
                            AddUsingStatements(newFile, references);
                            //string[] classes={"Program"};
                            string[] methods = { methodName };
                            AddPexAttribute(newFile, null, methods);
                            i++;
                        }
                    }
                }
            }
            return i;
        }

        public static void CreateProjectFile(string filePath, string file)
        {
            string[] lines = File.ReadAllLines("..\\..\\projectFileTemplate.txt");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Trim() == "<files/>")
                {
                    sb.AppendLine("  <Compile Include=\"" + file + "\" />");
                }
                else
                {
                    sb.AppendLine(lines[i]);
                }
            }
            File.WriteAllText(filePath, sb.ToString());
        }

        public static void CreateProjectFile(string filePath, string[] files)
        {
            string[] lines = File.ReadAllLines("..\\..\\projectFileTemplate.txt");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Trim() == "<files/>")
                {
                    foreach (var file in files)
                    {
                        sb.AppendLine("  <Compile Include=\"" + file + "\" />");
                    }
                }
                else
                {
                    sb.AppendLine(lines[i]);
                }
            }
            File.WriteAllText(filePath, sb.ToString());
        }

        public static void CreateAssemblyFile(string filePath, string assemblyName)
        {
            string[] lines = File.ReadAllLines("..\\..\\assemblyFileTemplate.txt");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (line.Length > 1 && line[0] == '[')
                {
                    if (line.Contains("AssemblyTitle"))
                    {
                        sb.AppendLine("[assembly: AssemblyTitle(\"" + assemblyName + "\")]");
                        continue;
                    }
                    else if (line.Contains("AssemblyProduct"))
                    {
                        sb.AppendLine("[assembly: AssemblyProduct(\"" + assemblyName + "\")]");
                        continue;
                    }
                }
                sb.AppendLine(lines[i]);
            }
            File.WriteAllText(filePath, sb.ToString());
        }

        public static void CopyDirectory(string sourceDir, string destDir)
        {
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            if (sourceDir[sourceDir.Length - 1] != '\\')
            {
                sourceDir += '\\';
            }

            if (destDir[destDir.Length - 1] != '\\')
            {
                destDir += '\\';
            }

            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            DirectoryInfo destDirInfo = new DirectoryInfo(destDir);

            foreach (var fileInfo in sourceDirInfo.GetFiles())
            {
                string destPath = Path.Combine(destDir + fileInfo.Name);
                fileInfo.CopyTo(destPath, true);
            }

            foreach (var dirInfo in sourceDirInfo.GetDirectories())
            {
                string destPath = Path.Combine(destDir + dirInfo.Name);
                CopyDirectory(dirInfo.FullName, destPath);
            }
        }

        public static string GetAssemblyFileOfProject(string projectDir, string assemblyName)
        {
            string dir = projectDir + @"\bin\Debug";
            foreach (var file in Directory.GetFiles(dir))
            {
                if (file.Contains(assemblyName + ".dll"))
                {
                    return file;
                }
            }
            throw new Exception("Assembly not found");
        }

        //if the reference already exists, it will be ignored
        public static void AddUsingStatements(string filePath, string[] referenceNames)
        {
            List<string> existingReferences = new List<string>();
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                string[] tokens = line.Split();
                if (tokens[0] == "namespace" || tokens[0] == "public")
                {
                    break;
                }
                if (tokens[0] == "using")
                {
                    for (int j = 1; j < tokens.Length; j++)
                    {
                        if (tokens[j].Length >= 1 && tokens[j][tokens[j].Length - 1] == ';')
                        {
                            existingReferences.Add(tokens[j].Substring(0, tokens[j].Length - 1));
                            break;
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            bool added = false;
            foreach (string reference in referenceNames)
            {
                if (!existingReferences.Contains(reference))
                {
                    added = true;
                    sb.AppendLine("using " + reference + ";");
                }
            }
            if (added)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    sb.AppendLine(lines[i]);
                }
                File.WriteAllText(filePath, sb.ToString());
            }
        }

        public static void AddPexAttribute(string file)
        {
            string[] lines = File.ReadAllLines(file);
            StringBuilder sb = new StringBuilder();
            bool added = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                string[] tokens = line.Split();
                if (tokens[0] == "public")
                {
                    string start = lines[i].Substring(0, lines[i].IndexOf("public"));
                    if (tokens.Contains("class"))
                    {
                        string className = "";
                        bool flag = false;
                        for (int j = 0; j < tokens.Length; j++)
                        {
                            if (tokens[j] == "class")
                            {
                                flag = true;
                                continue;
                            }
                            if (flag && tokens[j] != "")
                            {
                                className = tokens[j];
                                break;
                            }
                        }

                        List<string> existingAttributes = new List<string>();
                        int index = i - 1;
                        while (index >= 0)
                        {
                            string l = lines[index].Trim();
                            if (l.Length > 2
                                && l[0] == '[' && l[l.Length - 1] == ']')
                            {
                                string attr = l.Substring(1, l.Length - 2).Trim();
                                existingAttributes.Add(attr);
                            }
                            else if (l != "")
                            {
                                break;
                            }
                            index--;
                        }
                        bool contains = false;
                        foreach (string attr in existingAttributes)
                        {
                            if (attr.Contains("PexClass"))
                            {
                                contains = true;
                                break;
                            }
                        }
                        if (!contains)
                        {
                            added = true;
                            sb.AppendLine(start + "[PexClass(typeof(" + className + "))]");
                            //sb.AppendLine(start + "[PexClass]");
                        }
                    }
                    else if (line.Contains('('))
                    {
                        string[] temps = line.Split();
                        if (temps[1].Contains('('))
                        {
                            sb.AppendLine(lines[i]);
                            continue;
                        }

                        List<string> existingAttributes = new List<string>();
                        int index = i - 1;
                        while (index >= 0)
                        {
                            string l = lines[index].Trim();
                            if (l.Length > 2
                                && l[0] == '[' && l[l.Length - 1] == ']')
                            {
                                string attr = l.Substring(1, l.Length - 2).Trim();
                                existingAttributes.Add(attr);
                            }
                            else if (l != "")
                            {
                                break;
                            }
                            index--;
                        }
                        bool contains = false;
                        foreach (string attr in existingAttributes)
                        {
                            if (attr.Contains("PexMethod"))
                            {
                                contains = true;
                                break;
                            }
                        }
                        if (!contains)
                        {
                            added = true;
                            sb.AppendLine(start + "[PexMethod(TestEmissionFilter=PexTestEmissionFilter.All)]");
                            //sb.AppendLine(start + "[PexMethod]");
                        }
                    }
                }
                sb.AppendLine(lines[i]);
            }
            if (added)
            {
                File.WriteAllText(file, sb.ToString());
            }
        }

        public static void AddPexAttributeForDir(string topDir)
        {
            string[] references = { "Microsoft.Pex.Framework" };
            foreach (var file in Directory.GetFiles(topDir))
            {
                if (file.EndsWith(".cs") && !file.EndsWith("\\AssemblyInfo.cs"))
                {
                    AddUsingStatements(file, references);
                    AddPexAttribute(file);
                }
            }
            foreach (var dir in Directory.GetDirectories(topDir))
            {
                AddPexAttributeForDir(dir);
            }
        }

        public static void AddPexAttribute(string file, string[] classes, string[] methods)
        {
            //if((classes==null||classes.Length==0) && (methods==null||methods.Length==0)){
            //    AddPexAttribute(file);
            //    return;
            //}
            string[] lines = File.ReadAllLines(file);
            StringBuilder sb = new StringBuilder();
            bool added = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                string[] tokens = line.Split();
                if (tokens[0] == "public")
                {
                    string start = lines[i].Substring(0, lines[i].IndexOf("public"));
                    if (tokens.Contains("class"))
                    {
                        string className = "";
                        bool flag = false;
                        for (int j = 0; j < tokens.Length; j++)
                        {
                            if (tokens[j] == "class")
                            {
                                flag = true;
                                continue;
                            }
                            if (flag && tokens[j] != "")
                            {
                                className = tokens[j];
                                break;
                            }
                        }

                        if (classes == null || classes.Contains(className))
                        {
                            List<string> existingAttributes = new List<string>();
                            int index = i - 1;
                            while (index >= 0)
                            {
                                string l = lines[index].Trim();
                                if (l.Length > 2
                                    && l[0] == '[' && l[l.Length - 1] == ']')
                                {
                                    string attr = l.Substring(1, l.Length - 2).Trim();
                                    existingAttributes.Add(attr);
                                }
                                else if (l != "")
                                {
                                    break;
                                }
                                index--;
                            }
                            bool contains = false;
                            foreach (string attr in existingAttributes)
                            {
                                if (attr.Contains("PexClass"))
                                {
                                    contains = true;
                                    break;
                                }
                            }
                            if (!contains)
                            {
                                added = true;
                                sb.AppendLine(start + "[PexClass(typeof(" + className + "))]");
                                //sb.AppendLine(start + "[PexClass]");
                            }
                        }
                    }
                    else if (methods != null && methods.Length != 0 && line.Contains('('))
                    {
                        //check constructor
                        string[] temps = line.Split();
                        if (temps[1].Contains('('))
                        {
                            sb.AppendLine(lines[i]);
                            continue;
                        }

                        string methodName = "";
                        string temp = line.Substring(0, line.IndexOf('(')).Trim();
                        string[] tks = temp.Split();
                        methodName = tks[tks.Length - 1];

                        if (methods.Contains(methodName))
                        {
                            List<string> existingAttributes = new List<string>();
                            int index = i - 1;
                            while (index >= 0)
                            {
                                string l = lines[index].Trim();
                                if (l.Length > 2
                                    && l[0] == '[' && l[l.Length - 1] == ']')
                                {
                                    string attr = l.Substring(1, l.Length - 2).Trim();
                                    existingAttributes.Add(attr);
                                }
                                else if (l != "")
                                {
                                    break;
                                }
                                index--;
                            }
                            bool contains = false;
                            foreach (string attr in existingAttributes)
                            {
                                if (attr.Contains("PexMethod"))
                                {
                                    contains = true;
                                    break;
                                }
                            }
                            if (!contains)
                            {
                                added = true;
                                sb.AppendLine(start + "[PexMethod(TestEmissionFilter=PexTestEmissionFilter.All)]");
                                //sb.AppendLine(start + "[PexMethod]");
                            }
                        }
                    }
                }
                sb.AppendLine(lines[i]);
            }
            if (added)
            {
                File.WriteAllText(file, sb.ToString());
            }
        }


    }
}
