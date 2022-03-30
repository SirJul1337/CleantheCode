using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace CleantheCode
{
    public class Manager
    {


        public string GetDiskMetadata()
        {
            string output = "";
            System.Management.ManagementScope managementScope = new System.Management.ManagementScope();

            System.Management.ObjectQuery objectQuery = new System.Management.ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);

            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            output +="Disk Meta Data: ";
            foreach (ManagementObject managementObject in managementObjectCollection)
            {

                output += ("\nDisk Name : " + managementObject["Name"].ToString());

                output += ("\nFreeSpace: " + managementObject["FreeSpace"].ToString());

                output += ("\nDisk Size: " + managementObject["Size"].ToString());

                output += ("\n---------------------------------------------------");

            }
            return output;
        }
        public string GetHardDiskSerialNumber(string drive = "C")
        {
            string output = "";
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
            managementObject.Get();
            output += "\nHarddisk Serialnumber\n";
            output += managementObject["VolumeSerialNumber"].ToString();
            output += ("\n---------------------------------------------------");
            return output;

        }
        public string Proccessors()
        {
            string output = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            output += "\nProcssor Usage";
            foreach (ManagementObject obj in searcher.Get())
            {
                var usage = obj["PercentProcessorTime"];
                var name = obj["Name"];
                output += "\n";
                output +=("CPU "+name + " : " + usage+"%");

            }
            output += ("\n---------------------------------------------------");
            return output;
        }
        public string MainMemory()
        {
            string output = "";
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            output += "\nMemory size: ";
            foreach (ManagementObject result in results)
            {
                output += ("\nTotal Visible Memory: {0}KB", result["TotalVisibleMemorySize"]);
                output += ("\nFree Physical Memory: {0}KB", result["FreePhysicalMemory"]);
                output += ("\nTotal Virtual Memory: {0}KB", result["TotalVirtualMemorySize"]);
                output += ("\nFree Virtual Memory: {0}KB", result["FreeVirtualMemory"]);
            }
            output += ("\n---------------------------------------------------");
            return output;
        }




        public string Test()
        {
            string output = "";
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            output += "\nTest\n";
            foreach (ManagementObject result in results)
            {

                output +="\nUser: "+result["RegisteredUser"];
                output +="\nOrg.: " + result["Organization"];
                output +="\nO/S :"+ result["Name"];
            }
            output += ("\n---------------------------------------------------");
            return output;
        }

        public string BootDevice()
        {
            string output = "";
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");

            //create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

            //create object searcher
            ManagementObjectSearcher searcher =
                                    new ManagementObjectSearcher(scope, query);

            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = searcher.Get();

            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // access properties of the WMI object
                output+=("\nBootDevice : ", m["BootDevice"]);

            }
            output += ("\n---------------------------------------------------");
            return (output);


        }
        public string ListAllServices()
        {
            string output = "";
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();

            output += "There are "+objectCollection.Count+"Windows services: " ;

            foreach (ManagementObject windowsService in objectCollection)
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        output+=("\nWindows service property name: ", serviceProperty.Name);
                        output+=("\nWindows service property value: ", serviceProperty.Value);
                    }
                }
                output+=("\n---------------------------------------");
            }
            return output;
        }
    }
}
