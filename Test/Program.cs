using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace Test
{
    class Program
    {
        [DllImportAttribute("User32.dll")]
        private static extern IntPtr FindWindow(String ClassName, String WindowName);


        [DllImportAttribute("User32.dll")]
        private static extern IntPtr SetForegroundWindow(int hWnd);


        [DllImport("user32.dll", SetLastError=true, CharSet= CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int status);


        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic(IntPtr hWnd);


        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsZoomed(IntPtr hWnd);


        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        static void Main(string[] args)

          
        {
            //TEST();
            //Console.ReadKey();
            //TEST();

            IntPtr hWnd = FindWindow(null, "Калькулятор");


        }

        public static void TEST()
        {
            IntPtr hWnd = FindWindow(null, "Калькулятор");
            Console.WriteLine("--" + hWnd);
            StateWrite(hWnd);
            

            //ShowWindow(hWnd, 0);
            //Console.WriteLine("0");
            //StateWrite(hWnd);
            ShowWindow(hWnd, 6);
            Console.WriteLine("6");
            StateWrite(hWnd);
            //ShowWindow(hWnd, 5);
            //Console.WriteLine("5");
            //StateWrite(hWnd);
            ShowWindow(hWnd, 9);
            Console.WriteLine("9");
            StateWrite(hWnd);
           
        }

        public static void StateWrite(IntPtr hWnd)
        {
            if (hWnd == IntPtr.Zero)
                Console.WriteLine("Window not found");
            else
            if (IsIconic(hWnd))
                Console.WriteLine("Minimize state");
            else
                if (IsZoomed(hWnd))
                Console.WriteLine("Maximized state");
            else
                Console.WriteLine("Normal");
        }
    }
}

