using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;

namespace Infrastructure
{
    public class UtilityBase
    {
        public static string GetMacAddress()
        {
            string empty = string.Empty;
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    if (empty.Trim().Length > 0)
                        empty += "|";
                    empty += BitConverter.ToString(networkInterface.GetPhysicalAddress().GetAddressBytes());
                }
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    if (empty.Trim().Length > 0)
                        empty += "|";
                    empty += BitConverter.ToString(networkInterface.GetPhysicalAddress().GetAddressBytes());
                }
            }
            return empty;
        }

        public static Stream FileToStream(string fileFullName)
        {
            using (FileStream fileStream = new FileStream(fileFullName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                fileStream.Close();
                return (Stream)new MemoryStream(buffer);
            }
        }
    }
}
