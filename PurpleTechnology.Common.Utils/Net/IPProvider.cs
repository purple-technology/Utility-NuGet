using System;
using System.Net;

namespace PurpleTechnology.Common.Utils.Net
{
    /// <summary>
    /// An IP address utilities.
    /// </summary>
    public class IPProvider
    {
        /// <summary>
        /// Returns the client's Internet public address.
        /// <para>If network connection is unavailable or remote API unreachable, IPAddress.None is returned.</para>
        /// </summary>
        /// <returns>The client Internet public address.</returns>
        public static IPAddress GetPublicIpAddress()
        {
            IPAddress ipAddress = IPAddress.None;
            try
            {
                ipAddress = IPAddress.Parse(new WebClient().DownloadString("https://api.ipify.org"));
            }
            catch
            {
                // Exceptions are swallowed, IPAddress.None (255.255.255.255) is returned.
            }
            return ipAddress;
        }
    }
}