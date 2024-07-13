using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace HelperLib;
public static class NetworkHelper
{
    public static bool Ping(string address, int timeoutMilliseconds)
    {
        try
        {
            return new Ping().Send(address, timeoutMilliseconds).Status == IPStatus.Success;
        }
        catch
        {
            return false;
        }
    }

    public static bool CheckServerPort(string ip, int timeout)
    {
        int port = 80;

        if (ip.Contains(':'))
        {
            var xs = ip.Split(':');
            ip = xs[0];
            int.TryParse(xs[1], out port);
        }
        return
            CheckServerPort(ip, port, timeout);
    }


    public static bool CheckServerPortUrl(string url, int timeout)
    {
        return
            CheckServerPort(
                new Uri(url),
                timeout
            );
    }

    public static bool CheckServerPort(Uri u, int timeout)
    {
        return
            CheckServerPort(
                u.Host,
                u.Port,
                timeout
            );
    }

    public static bool CheckServerPort(string ip, int port, int timeout)
    {
        try
        {
            var tcp = new System.Net.Sockets.TcpClient();
            var task = tcp.BeginConnect(ip, port, null, null);
            bool ok = false;
            var sw = Stopwatch.StartNew();
            while(!ok)
            {
                ok = task.IsCompleted;
                if (!ok)
                {
                    if (sw.ElapsedMilliseconds > timeout)
                    {
                        break;
                    }

                    Thread.Sleep(100);	
                }
            }

            return ok;
        }
        catch
        {
            return false;
        }
    }

    public static string GetLocalIPAddress()
    {
        try
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
        }
        catch { }

        return "0.0.0.0";
    }
    public static string[] GetLocalIPAddresses()
    {
        var xs = new List<string>();
        xs.Add(Dns.GetHostName());
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            xs.Add(string.Concat(ip.ToString(), "=", ip.AddressFamily.ToString()));
        }

        return xs.ToArray();
    }

    internal static string? GetHostName()
    {
        try
        {
            return Dns.GetHostName();
        }
        catch
        {
            return null;
        }
    }
}
