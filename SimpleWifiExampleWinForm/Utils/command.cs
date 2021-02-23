using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWifiExampleWinForm
{
    public class Command
    {
        /// <summary>
        /// Process类执行DOS命令
        /// </summary>
        /// <param name="command">执行的命令行</param>
        /// <returns></returns>
        public static string RunCommand(string cmd, string args = "")
        {
            string returnStr = null;
            //實例一個Process類，啟動一個獨立進程
            Process p = new Process();
            //Process類有一個StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：
            p.StartInfo.FileName = cmd;// "netsh.exe";  //設定程序名
            p.StartInfo.Arguments = args;            //設定程式執行參數
            p.StartInfo.Verb = "runas";
            p.StartInfo.UseShellExecute = false;        //關閉Shell的使用
            p.StartInfo.RedirectStandardInput = true;   //重定向標準輸入
            p.StartInfo.RedirectStandardOutput = true;  //重定向標準輸出
            p.StartInfo.RedirectStandardError = true;   //重定向錯誤輸出
            p.StartInfo.CreateNoWindow = true;          //設置不顯示窗口
            p.Start();                                  //啟動
            returnStr = p.StandardOutput.ReadToEnd();     //赋值
            p.Dispose();                                //释放资源
            return returnStr;        //從輸出流取得命令執行結果

        }
        [DllImport("cellcore.dll")]
        public static extern int GetCellLine();
        [DllImport("cellcore.dll")]
        public static extern int lineSetEquipmentState(IntPtr hLine, int LINEEQUIPSTATE_MINIMUM);
        [DllImport("cellcore.dll")]
        public static extern int lineClose(IntPtr hLine);
        [DllImport("cellcore.dll")]
        public static extern int lineShutdown(IntPtr m_hLineApp);
        [DllImport("cellcore.dll")]
        public static extern int lineRegister(IntPtr hLine, int LINEREGMODE_AUTOMATIC, IntPtr lpszOperator, int dwOperatorFormat);






    }
}
