using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Globalization;
using MetaProject;

namespace Pex4Fun
{
    public class ExtractPexResults
    {
        //List containing string arrays of the passed & failed tests' method bodies
        //static List<string[]> g_PassedTests = new List<string[]>();
        //static List<string[]> g_FailedTests = new List<string[]>();
        static HashSet<string[]> g_PassedTests = new HashSet<string[]>();
        static HashSet<string[]> g_FailedTests = new HashSet<string[]>();
        static string g_failType;


        //12/03/18, By Jonathan
        //This function extracts Pex results for a single project in the editedMetaProject folder
        public static Tuple<HashSet<string[]>, HashSet<string[]>, string> ExtractTestsForEditedMetaProject(string editedMetaProject, string fileName, string className, string methodName, string assemblyName)
        {
            string assemblyFile = FileModifier.GetAssemblyFileOfProject(editedMetaProject, assemblyName);
            MethodInfo method = RunTest.GetMethodDefinition(assemblyFile, className, methodName);
            List<Test> tests = ExtractTestsForProject(editedMetaProject, method);
            if (tests != null)
            {
                //Try to create "PexTests" directory. Nothing happens if already exists
                System.IO.Directory.CreateDirectory(editedMetaProject + @"\PexTests");
                string xmlFileName = editedMetaProject + @"\PexTests\" + fileName + "_PexTests.xml";
                Serializer.SerializeTests(tests, xmlFileName);
            }

            //Notify caller of infin runtime / null ref exception
            return Tuple.Create(g_PassedTests, g_FailedTests, g_failType);
        }

        public static List<Test> ExtractTestsForProject(string projectDir, MethodInfo method)
        {
            var paras = method.GetParameters();
            List<Test> tests = new List<Test>();
            string reportsDir = projectDir + @"\bin\Debug\reports\";
            if (!Directory.Exists(reportsDir))
                return null;
            string reportDir = Directory.GetDirectories(reportsDir)[0];
            string reportFile = reportDir + "\\report.per";
            XmlDocument doc = new XmlDocument();
            doc.Load(reportFile);
            g_PassedTests.Clear(); //reset
            g_FailedTests.Clear(); //reset
            g_failType = ""; //reset
            foreach (XmlNode node in doc.SelectNodes(
                "/pex/assembly/fixture/exploration/generatedTest"))
            {
                //node is the generted test
                Test test = new Test();
                string failed = null;
                //Ignores duplicate tests (anything that's not normaltermination / exception)
                if (node.Attributes["status"] != null && !(node.Attributes["status"].Value.Equals("normaltermination")
                    || node.Attributes["status"].Value.Equals("exception")))
                {
                    continue;
                }

                else if (node.Attributes["status"].Value.Equals("pathboundsexceeded"))
                {
                    test.Result = TestResult.InfinRun;
                }

                else if (node.Attributes["failed"] != null)
                {
                    failed = node.Attributes["failed"].Value;
                }
                else
                {
                    failed = "false";
                }
                if (failed == "true")
                {
                    //Check if failure was due to PexAssertion or Exception
                    //Check if status==exception THEN check if 'source' contains 
                    if (node.Attributes["status"].Value.Equals("exception"))
                        if (node.InnerXml.Contains("throw new Exception(\"Student submission is")) //Aka: s1 >= s2
                            g_failType = "exception";
                        else if (node.InnerXml.Contains("PexAssert.IsTrue(")) //Aka: s2 >= s1
                            g_failType = "assertion";

                    //Mark as failed and record in structure
                    test.Result = TestResult.Failed;
                    string[] justMethodBody = Program.returnJustMethodBody(node.InnerText.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
                    g_FailedTests.Add(justMethodBody);
                }
                else
                {
                    test.Result = TestResult.Passed;
                    string[] justMethodBody = Program.returnJustMethodBody(node.InnerText.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
                    g_PassedTests.Add(justMethodBody);
                }
                int i = 0;
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name == "value" && i < paras.Length)
                    {
                        string input = child.InnerText;
                        //input.Replace("&apos;", "\'");
                        //input.Replace("&quot;", "\"");

                        string paraType = paras[i++].ParameterType.Name;
                        switch (paraType)
                        {
                            case "Int32":
                                if (input.ToLower() == "int.maxvalue")
                                {
                                    test.TestInputs.Add(Int32.MaxValue);
                                }
                                else if (input.ToLower() == "int.minvalue")
                                {
                                    test.TestInputs.Add(Int32.MinValue);
                                }
                                else
                                {
                                    test.TestInputs.Add(Int32.Parse(input));
                                }
                                break;
                            case "String":
                                if (input == "null")
                                {
                                    test.TestInputs.Add(null);
                                }
                                else if (input.StartsWith("new string("))
                                {
                                    input = input.Replace("\"", "");
                                    string[] tokens = input.Split(',');
                                    string token1 = tokens[0].Trim();
                                    int start = token1.IndexOf('\'');
                                    string str = token1.Substring(start + 1, token1.Length - start - 2);
                                    string token2 = tokens[1].Trim();
                                    string numStr = token2.Substring(0, token2.Length - 1);
                                    int num = Int32.Parse(numStr);
                                    str = Utility.ParseString(str);
                                    StringBuilder sb = new StringBuilder();
                                    for (int j = 0; j < num; j++)
                                    {
                                        sb.Append(str);
                                    }
                                    test.TestInputs.Add(sb.ToString());
                                }
                                else
                                {
                                    //input = input.Replace("\"", "");
                                    input = input.Substring(1, input.Length - 2);
                                    input = Utility.ParseString(input);
                                    test.TestInputs.Add(input);
                                }
                                break;
                            case "Char":
                                input = input.Replace("\'", "");
                                input = Utility.ParseString(input);
                                if (input.ToLower() == "char.maxvalue")
                                {
                                    test.TestInputs.Add(Char.MaxValue);
                                }
                                else if (input.ToLower() == "char.minvalue")
                                {
                                    test.TestInputs.Add(Char.MinValue);
                                }
                                else
                                {
                                    test.TestInputs.Add(Char.Parse(input));
                                }
                                break;
                            case "Boolean":
                                if (input.StartsWith("t"))
                                {
                                    input = input.Substring(0, 4);
                                }
                                else
                                {
                                    input = input.Substring(0, 5);
                                }
                                test.TestInputs.Add(Boolean.Parse(input));
                                break;
                            case "Byte":
                                if (input.ToLower() == "byte.maxvalue")
                                {
                                    test.TestInputs.Add(Byte.MaxValue);
                                }
                                else if (input.ToLower() == "byte.minvalue")
                                {
                                    test.TestInputs.Add(Byte.MinValue);
                                }
                                else
                                {
                                    test.TestInputs.Add(Byte.Parse(input, NumberStyles.HexNumber));
                                }
                                break;
                            case "Int32[]":
                                int[] array;
                                if (input == "null")
                                {
                                    array = null;
                                }
                                else if (input == "{}")
                                {
                                    array = new int[0];
                                }
                                else if (input.Contains("Length=") && input.Contains("..."))
                                {
                                    int start = input.IndexOf("Length=") + 7;
                                    int end = input.IndexOf(";");
                                    string sizeStr = input.Substring(start, end - start);
                                    int size = Int32.Parse(sizeStr);
                                    array = new int[size];
                                }
                                else
                                {
                                    string str;
                                    if (!input.Contains("Length="))
                                    {
                                        str = input.Substring(1, input.Length - 2);
                                    }
                                    else
                                    {
                                        str = input.Substring(input.IndexOf(';') + 2);
                                        str = str.Substring(0, str.Length - 1);
                                    }
                                    string[] tokens = str.Split(',');
                                    array = new int[tokens.Length];
                                    for (int j = 0; j < tokens.Length; j++)
                                    {
                                        if (tokens[j].Trim().ToLower() == "int.maxvalue")
                                        {
                                            array[j] = Int32.MaxValue;
                                        }
                                        else if (tokens[j].Trim().ToLower() == "int.minvalue")
                                        {
                                            array[j] = Int32.MinValue;
                                        }
                                        else
                                        {
                                            array[j] = Int32.Parse(tokens[j].Trim());
                                        }
                                    }
                                }
                                test.TestInputs.Add(array);
                                break;
                            case "List":
                                MetaProgram.List l = new MetaProgram.List();
                                string parsedListAsString = new String(input.Where(Char.IsDigit).ToArray());
                                foreach (char c in parsedListAsString)
                                {
                                    l.addToEndSolutionForReal((int)Char.GetNumericValue(c));
                                }
                                //TODO: Parse the "input" var for NUMBERS (i.e. 0, 1) and then call addToEnd on "l" on a foreach(), and then do test.TestInputs.add(input)
                                //Tip: Refer to C:\Users\rayjo_000\Documents\CodeSimilarity\editedMetaProject\bin\Debug\reports\181212.103424.7620.pex\report.per
                                test.TestInputs.Add(l);
                                break;

                            default:
                                throw new Exception("Unhandled para type: " + paraType);
                        }
                    }
                }
                tests.Add(test);
            }
            return tests;
        }
    }
}
