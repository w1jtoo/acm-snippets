using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using static System.Console;

namespace B
{
    internal static class Program
    {
        private const long Mod = 1_000_000_000 + 7;

        private static void Main()
        {
        }

        #region stdutils

#if FILE_OUTOUT
        private static readonly string ProjectDirectory =
            Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        private static readonly string OutPutFileName = Path.Combine(ProjectDirectory, "output.txt");
        private static readonly string InputFileName = Path.Combine(ProjectDirectory, "input.txt");

        static Program()
        {
            File.Delete(OutPutFileName);

            var writer = new StreamWriter(OutPutFileName, true);
            writer.AutoFlush = true;
            SetOut(writer);

            var reader = new StreamReader(InputFileName);
            SetIn(reader);
        }
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Print(string value)
        {
            Out.WriteLine(value);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string Input()
        {
            return In.ReadLine()?.Trim() ?? throw new Exception("Empty input");
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T As<T>(this string str) where T : IConvertible
        {
            if (typeof(T) == typeof(int))
                return (T)(object)int.Parse(str);
            if (typeof(T) == typeof(long))
                return (T)(object)long.Parse(str);
            if (typeof(T) == typeof(string))
                return (T)(object)str;
            if (typeof(T) == typeof(short))
                return (T)(object)short.Parse(str);

            return (T)Convert.ChangeType(str, typeof(T));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T[] AsArray<T>(this string str, string separator = " ") where T : IConvertible
        {
            return str.Split(separator).Select(As<T>).ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static (T1, T2) As<T1, T2>(this string str, string separator = " ")
            where T1 : IConvertible where T2 : IConvertible
        {
            var items = str.Split(separator);

            return (items[0].As<T1>(), items[1].As<T2>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static (T1, T2, T3) As<T1, T2, T3>(this string str, string separator = " ") where T1 : IConvertible
            where T2 : IConvertible
            where T3 : IConvertible
        {
            var items = str.Split(separator);

            return (items[0].As<T1>(), items[1].As<T2>(), items[2].As<T3>());
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static (T1, T2, T3, T4) As<T1, T2, T3, T4>(this string str, string separator = " ")
            where T1 : IConvertible
            where T2 : IConvertible
            where T3 : IConvertible
            where T4 : IConvertible
        {
            var items = str.Split(separator);

            return (items[0].As<T1>(), items[1].As<T2>(), items[2].As<T3>(), items[3].As<T4>());
        }

        #endregion
    }
}