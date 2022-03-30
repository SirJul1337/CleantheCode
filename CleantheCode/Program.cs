using CleantheCode;
using System;
using System.Collections.Generic;
using System.Management;

namespace WMIApp
{
    class Program
    {
        static Manager manager = new Manager();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Use key press to go to next method");
            Console.WriteLine(manager.GetDiskMetadata());
            Console.ReadKey();
            Console.WriteLine(manager.GetHardDiskSerialNumber());
            Console.ReadKey();
            Console.WriteLine(manager.Proccessors());
            Console.ReadKey();
            Console.WriteLine(manager.MainMemory());
            Console.ReadKey();
            Console.WriteLine(manager.Test());
            Console.ReadKey();
            Console.WriteLine("BootDevice");
            Console.WriteLine(manager.BootDevice());
            Console.ReadKey();
            Console.WriteLine("Process Searching");
            Console.WriteLine(manager.ListAllServices()); 





            Console.ReadKey();

        } //Slut main


        //This method isnt being used anywhere, so i out commented it
        //static List<string> PopulateDisk()

        //{

        //    List<string> disk = new List<string>();

        //    SelectQuery selectQuery = new SelectQuery("Win32_LogicalDisk");

        //    ManagementObjectSearcher mnagementObjectSearcher = new ManagementObjectSearcher(selectQuery);

        //    foreach (ManagementObject managementObject in mnagementObjectSearcher.Get())

        //    {

        //        disk.Add(managementObject.ToString());

        //    }

        //    return disk;

        //}








    }

}
