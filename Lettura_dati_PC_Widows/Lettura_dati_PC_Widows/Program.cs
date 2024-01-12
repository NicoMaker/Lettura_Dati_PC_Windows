using System;
using System.Management;
using Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

Data data = new Data();

string ramInfo = data.GetRamInfo();
string romInfo = data.GetRomInfo();
string cpuInfo = data.GetCpuInfo();

Console.WriteLine(ramInfo);
Console.WriteLine(romInfo);
Console.WriteLine(cpuInfo);