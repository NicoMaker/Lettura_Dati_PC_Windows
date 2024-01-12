using System.Management;
namespace Windows;
class Data
{
    public string GetRamInfo()
    {
        ObjectQuery query = new ObjectQuery("SELECT FreePhysicalMemory, TotalVisibleMemorySize FROM Win32_OperatingSystem");
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

        foreach (ManagementObject mo in searcher.Get())
        {
            ulong freeRam = (ulong)mo["FreePhysicalMemory"];
            ulong totalRam = (ulong)mo["TotalVisibleMemorySize"];
            ulong usedRam = totalRam - freeRam;


            return $"RAM Used: {usedRam / (1024 * 1024)} GB, RAM Free: {freeRam / (1024 * 1024)} GB, RAM Total: {totalRam / (1024 * 1024)} GB";
        }

        return "RAM information not available";
    }


    public string GetRomInfo()
    {
        ObjectQuery query = new ObjectQuery("SELECT FreeSpace, Size FROM Win32_LogicalDisk WHERE DeviceID = 'C:'");
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

        foreach (ManagementObject mo in searcher.Get())
        {
            ulong freeSpace = (ulong)mo["FreeSpace"];
            ulong totalSize = (ulong)mo["Size"];
            ulong usedSpace = totalSize - freeSpace;

            return $"ROM Used: {usedSpace / (1024 * 1024 * 1024)} GB, ROM Free: {freeSpace / (1024 * 1024 * 1024)} GB, ROM Total: {totalSize / (1024 * 1024 * 1024)} GB";
        }

        return "ROM information not available";
    }

    public string GetCpuInfo()
    {
        ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Processor");
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
        string cpuInfo = "";

        foreach (ManagementObject mo in searcher.Get())
            cpuInfo = $"CPU: {mo["Name"]}, Cores: {mo["NumberOfCores"]}, Clock Speed: {mo["MaxClockSpeed"]} MHz";

        return cpuInfo;
    }
}