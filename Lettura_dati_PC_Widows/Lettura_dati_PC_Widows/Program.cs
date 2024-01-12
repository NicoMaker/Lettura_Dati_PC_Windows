using System;
using System.Management;
using Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

Data data = new Data();

Console.WriteLine(data.GetRamInfo());
Console.WriteLine(data.GetRomInfo());
Console.WriteLine(data.GetCpuInfo());