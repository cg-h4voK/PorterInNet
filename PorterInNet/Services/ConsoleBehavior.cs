using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet.Services
{
    public class ConsoleBehavior
    {
        #region Thread-Safe Singleton

        private ConsoleBehavior() { }
        static ConsoleBehavior() { }

        private static readonly ConsoleBehavior instance = new ConsoleBehavior();

        public static ConsoleBehavior Instance => instance;

        #endregion

        #region External

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        private const int SW_MAXIMIZE = 3;

        #endregion

        #region Methods

        public void Maximize()
        {
            var process = Process.GetCurrentProcess();
            ShowWindow(process.MainWindowHandle, SW_MAXIMIZE);
        }
        
        public void WriteLineCentered(string message)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (message.Length / 2)) + "}", message));
        }

        public void WriteDoubleLine()
        {
            Console.WriteLine();
            Console.WriteLine();
        }

        public void PressAnyKeyToExit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        #endregion

    }
}
