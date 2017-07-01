using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ems.Utils.Helper
{
    /*
     * C# 中动态调用C++动态链接；
     * Loadlibrary: 装载指定DLL动态库；
     * GetProcAddress：获得函数的入口地址；
     * Freelibrary: 从内存中卸载动态库；
     */
    public class NativeMethodHelper
    {
        #region Win API
        [DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
        public static extern int LoadLibrary(
            [MarshalAs(UnmanagedType.LPStr)] string lpLibFileName);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
        public static extern IntPtr GetProcAddress(int hModule,
            [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
        public static extern bool FreeLibrary(int hModule);
        #endregion

        private readonly int _hLib;

        public NativeMethodHelper(string dllPath)
        {
            _hLib = LoadLibrary(dllPath);
        }

        ~NativeMethodHelper()
        {
            FreeLibrary(_hLib);
        }

        // 将要执行的函数转换为委托
        public Delegate Invoke(string apiName, Type t)
        {
            var api = GetProcAddress(_hLib, apiName);
            return (Delegate)Marshal.GetDelegateForFunctionPointer(api, t);
        }

    }
}

/*
 * DllImport会按照顺序自动去寻找的地方：
 * 1、exe所在目录；
 * 2、System32目录；
 * 3、环境变量目录；
 */
