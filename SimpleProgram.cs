using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SimpleCsService
{
    public class Program
    {
        public static void Main()
        {
            string cmdFile = @"C:\OpenClaw\SystemHelper\simple_cmd.txt";
            string resultFile = @"C:\OpenClaw\SystemHelper\simple_result.txt";
            
            while (true)
            {
                try
                {
                    if (File.Exists(cmdFile))
                    {
                        string command = File.ReadAllText(cmdFile).Trim();
                        
                        if (command != "")
                        {
                            Process p = new Process();
                            p.StartInfo.FileName = "cmd.exe";
                            p.StartInfo.Arguments = "/c " + command;
                            p.StartInfo.UseShellExecute = false;
                            p.StartInfo.RedirectStandardOutput = true;
                            p.StartInfo.RedirectStandardError = true;
                            p.StartInfo.CreateNoWindow = true;
                            
                            p.Start();
                            string output = p.StandardOutput.ReadToEnd();
                            string error = p.StandardError.ReadToEnd();
                            p.WaitForExit();
                            
                            File.WriteAllText(resultFile, "EXIT:" + p.ExitCode + "\nOUT:" + output + "\nERR:" + error);
                            File.Delete(cmdFile);
                        }
                    }
                }
                catch
                {
                    // Silent fail
                }
                
                Thread.Sleep(100);
            }
        }
    }
}
