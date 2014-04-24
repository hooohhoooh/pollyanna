using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace WpfApp_Git_Test.Model
{
    public class GitClient
    {
        public GitClient()
        { }

        public static void Test()
        {
            string cmd = @"clone --no-local --recursive D:\git_backup_test\master D:\git_backup_test\master5";
            //string cmd = @"git clone --no-local --recursive D:\git_backup_test\master D:\git_backup_test\master5";

            Execute(cmd);
            
        }


        /// <summary>
        /// 引数
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static string ArgLinefromArgList(string[] args)
        {
            string format = "\"{0}\"";

            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (string s in args)
            {
                if (0 < i)
                {
                    sb.Append(" ");
                }

                sb.Append(string.Format(format, s));

                i++;
            }

            string arg = sb.ToString();

            return arg;
        }

        private static void Execute(string[] args)
        {
            try
            {
                string arg = ArgLinefromArgList(args);
                //string args =
                //    string.Format(format, mode) + " " +//動作モード
                //    string.Format(format, url) + " " +
                //    string.Format(format, title);

                //string path = GetTargetPath();

                Execute(arg);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public static int Execute(string arg)
        {
            int ret = -1;

            string path = GetServerPath();

            using (Process p = new Process())
            {
                p.StartInfo.FileName = path;

                p.StartInfo.Arguments = arg;

                //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                //bool retexit = p.WaitForExit(1000);

                //ret = p.ExitCode;

                //起動待機
                //p.WaitForInputIdle(1000);
            }

            return ret;
        }

        /// <summary>
        /// サーバー実行パス
        /// </summary>
        /// <returns></returns>
        private static string GetServerPath()
        {
            string path = string.Empty;

            //string codebase = Assembly.GetExecutingAssembly().CodeBase;
            //string dir = Path.GetDirectoryName(codebase);

            string gitdir = @"C:\Program Files (x86)\Git\bin";

            path = Path.Combine(gitdir, "git.exe");

            return path;
        }

    }
}
