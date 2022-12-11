using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using Microsoft.Win32;

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Net.Sockets;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

[MemoryDiagnoser(displayGenColumns: false)]
[DisassemblyDiagnoser]
[HideColumns("Error", "StdDev", "Median", "RatioSD")]
public partial class Program
{
    static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

    [Benchmark(Baseline = true)]
    public void Base()
    {
        const int numOfMaxElves = 3;

        var elfCals = new PriorityQueue<int, int>(numOfMaxElves);

        var currentElfCal = 0;

        foreach (var line in File.ReadLines("Day1/Input.txt"))
        {
            if (string.IsNullOrEmpty(line))
            {
                if (elfCals.Count == numOfMaxElves)
                    elfCals.EnqueueDequeue(currentElfCal, currentElfCal);
                else
                    elfCals.Enqueue(currentElfCal, currentElfCal);

                currentElfCal = 0;
            }
            else
            {
                currentElfCal += int.Parse(line);
            }
        }

        static (int max, int sum) GetCalDetails((int max, int sum) details, int cal) => (Math.Max(details.max, cal), details.sum + cal);

        var (max, sum) = elfCals.UnorderedItems.Select(x => x.Element)
                                               .Aggregate((0, 0), GetCalDetails);
    }

    [Benchmark]
    public void Test()
    {
        const int numOfMaxElves = 3;

        var elfCals = new List<int>(1000);

        var currentElfCal = 0;

        foreach (var line in File.ReadLines("Day1/Input.txt"))
        {
            if (string.IsNullOrEmpty(line))
            {
                elfCals.Add(currentElfCal);
                currentElfCal = 0;
            }
            else
            {
                currentElfCal += int.Parse(line);
            }
        }

        elfCals.Sort();
        var sum = elfCals.Take(numOfMaxElves).Sum();
        var max = elfCals.First();
    }
}