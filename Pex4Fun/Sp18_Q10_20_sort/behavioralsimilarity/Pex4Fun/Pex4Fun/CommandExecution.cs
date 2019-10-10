using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Pex4Fun
{
    public class Command
    {
        public string executable;
        public string arguments;
        public Command()
        {
        }
        public Command(string executable, string arguments)
        {
            this.executable = executable;
            this.arguments = arguments;
        }
    }

    public class CommandGenerator
    {
        public static Command GenerateRunPexCommand(string assemblyFile, string nameSpace = null, string type = null, string[] methods = null)
        {
            Command command = new Command();
            command.executable = @"C:\Program Files\Microsoft Pex\bin\pex.x86.exe";
            string arguments;
            arguments = " \"" + assemblyFile+"\"";
            if (nameSpace == null && type == null && methods == null)
            {
                command.arguments = arguments;
                return command;
            }

            //arguments += " /nf:" + nameSpace + "!" + " /tf:" + type + "!" + " /mf:";
            arguments += " /nf:" + nameSpace + " /tf:" + type + " /mf:";
            for (int i = 0; i < methods.Length; i++)
            {
                //arguments += methods[i]+"!";
                arguments += methods[i];
                if (i != methods.Length - 1)
                {
                    arguments += ";";
                }
            }
            command.arguments = arguments+" /nor";
            return command;
        }

        public static Command GenerateBuildCommand(string projectFile=null)
        {
            //Adding full path to MSBuild.exe
            Command command = new Command(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe", " \""+projectFile+"\""+" /t:rebuild");
            return command;
        }
    }

    public class CommandExecutor
    {
        public static bool ExecuteCommand (Command command)
        {
            Console.WriteLine("command to run: " + command.executable + command.arguments);
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            startInfo.FileName = command.executable;
            startInfo.Arguments = command.arguments;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    bool isCompilationSuccesful = (exeProcess.ExitCode == 0);
                    if (isCompilationSuccesful)
                    {
                        return true;
                    }

                }
                //Console.WriteLine("finished");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
    }
}
