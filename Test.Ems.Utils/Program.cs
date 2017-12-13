using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ems.Utils.Helper;

namespace Test.Ems.Utils
{
    class Program
    {
        static void Main(string[] args)
        {
            // new TestEmsUntils().TestMethod1();

            // new TestEmsUntils().TestMethod2();

            // new TestEmsUntils().TestMethod3();

            // new TestEmsUntils().TestMethod4();

            var stopwatch = new Stopwatch();
            // 第一次计时
            stopwatch.Start();

            // 判断当前Stopwatch的状态
            Console.WriteLine($"Stopwatch is running:{stopwatch.IsRunning}");

            // System.Threading.Thread.Sleep(1000); // 耗时操作

            // new TestEmsUntils().TestMethod7();
            var detectResult = new TestEmsUntils().TestMethod5();

            Console.WriteLine("detectResult：" + detectResult);

            // 识别结果解析成答案；
            // var answers = ReformerEmsHelper.ParseDetectResult(detectResult, 0);

            var answers = ReformerEmsHelper.ParseDetectResult2(detectResult, 0, 20);
            Console.WriteLine("answers：" + answers);

            stopwatch.Stop();

            // 这里使用时间差来输出
            Console.WriteLine($"Using Elapsed output runTime:{stopwatch.Elapsed.ToString()}");

            // 这里面使用毫秒来输出
            Console.WriteLine($"Using ElapsedMilliseconds output runTime:{stopwatch.ElapsedMilliseconds}");
            Console.WriteLine("===================================================");

            Console.ReadKey();
        }
    }
}
