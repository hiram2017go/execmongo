using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mongodb
{
    class Program
    {
        static void Main(string[] args)
        {
            ReusltData result = Exec();
        }

        public static ReusltData Exec()
        {
            string result = "";
            Process process = new Process();
            process.StartInfo.FileName = "/usr/local/mongodb/bin/mongoimport";//执行程序
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            string argus = "mongoimport -h 127.0.0.1 -d demo -c protocal /var/test/test-2016111609.txt";
            process.StartInfo.Arguments = argus;
            Hashtable filehash = new Hashtable();
            try
            {
                process.Start();
                process.StandardInput.WriteLine("exit");
                result = process.StandardOutput.ReadToEnd();
                Console.WriteLine("哈哈:{0}",argus);
                Console.WriteLine("返回结果是:{0}", result);
                //if (string.IsNullOrEmpty(result)) return new ReusltData { Code = -1, Message = "未获取到相应结果", hash = null };
                //string regexstr = @"([^\:]+)\:\s*(\w+.*)";
                //MatchCollection mc = Regex.Matches(result, regexstr, RegexOptions.IgnoreCase);

                //foreach (Match m in mc)
                //{
                //    if (m.Success)
                //    {
                //        string filepath = m.Groups[1].Value.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                //        if (filepths.Contains(filepath))
                //        {
                //            filehash[filepath] = m.Groups[2].Value;
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                return new ReusltData { Code = -1, Message = ex.Message, hash = null };
            }

            process.Close();
            return new ReusltData { Code = 0, Message = "成功", hash = filehash };
        }
    }

    public class ReusltData
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Hashtable hash { get; set; }
    }
}
