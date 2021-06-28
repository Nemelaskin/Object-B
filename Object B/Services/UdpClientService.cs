using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Object_B.Services
{
    public class UdpClientService
    {
         public static void AcceptCoordinates()
        {
            UdpClient client = new UdpClient(8001);
            IPEndPoint ip = null;
            byte[] data = client.Receive(ref ip);
            string message = Encoding.UTF8.GetString(data);
            System.Console.WriteLine("Message : " + message);
            client.Close();
        }
    }
}
