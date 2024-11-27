using System.Net;
using System.Net.Sockets;
using System.Text;


internal class Program
{
    static async Task Main(string[] args)
    {
        TcpClient client = new TcpClient();
        NetworkStream stream;
        try
        {
            await client.ConnectAsync(IPAddress.Loopback, 7777);
            stream = client.GetStream();
            await Console.Out.WriteLineAsync("Подключение успешно");
            while (true)
            {
                string message = Console.ReadLine()+'\n';
                stream.Write(Encoding.UTF8.GetBytes(message));
            }
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        finally
        {
            client.Close();
        }
    }
}