using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWifiExampleWinForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            bool createdNew;
            //系统能够识别有名称的互斥，因此可以使用它禁止应用程序启动两次
            //第二个参数可以设置为产品的名称:Application.ProductName
            //每次启动应用程序，都会验证名称为SingletonWinAppMutex的互斥是否存在
            Mutex mutex = new Mutex(false, Application.ProductName, out createdNew);

            //如果已运行，则在前端显示
            //createdNew == false，说明程序已运行
            if (!createdNew)
            {
                Process instance = GetExistProcess();
                if (instance != null)
                {
                    SetForegroud(instance);
                    Application.Exit();
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWin());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //MessageBox.Show(((Exception)e.ExceptionObject).Message + "\r\n" + ((Exception)e.ExceptionObject).StackTrace, "系统信息");
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //MessageBox.Show(e.Exception.Message + "\r\n" + e.Exception.StackTrace, "系统信息");
        }
        /// <summary>
        /// 查看程序是否已经运行
        /// </summary>
        /// <returns></returns>
        private static Process GetExistProcess()
        {
            Process currentProcess = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if ((process.Id != currentProcess.Id) &&
                    (Assembly.GetExecutingAssembly().Location == currentProcess.MainModule.FileName))
                {
                    return process;
                }
            }
            return null;
        }

        /// <summary>
        /// 使程序前端显示
        /// </summary>
        /// <param name="instance"></param>
        private static void SetForegroud(Process instance)
        {
            IntPtr mainFormHandle = instance.MainWindowHandle;
            if (mainFormHandle != IntPtr.Zero)
            {
                ShowWindowAsync(mainFormHandle, 1);
                SetForegroundWindow(mainFormHandle);
            }
        }

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
    }
}
