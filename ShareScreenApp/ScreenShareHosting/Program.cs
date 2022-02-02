using RemoteViewing.Vnc;
using RemoteViewing.Vnc.Server;
using RemoteViewing.Windows.Forms.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShareHosting
{

    static class Program
    {
        static IPAddress host;
        static int port;

        static string Password = "test";
        static VncServerSession Session;

        static void HandleConnected(object sender, EventArgs e)
        {
            Console.WriteLine("Client Connected!");
        }

        static void HandleConnectionFailed(object sender, EventArgs e)
        {
            Console.WriteLine("Connection Failed!");
        }

        static void HandleClosed(object sender, EventArgs e)
        {
            Console.WriteLine("Connection Closed!");
        }

        static void HandlePasswordProvided(object sender, PasswordProvidedEventArgs e)
        {
            e.Accept(Password.ToCharArray());
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            host = IPAddress.Parse("127.0.0.1");
            port = 5900;
           
            Console.WriteLine("Hosting on {0} : {1}, with password: {2}", host, port, Password);
            Console.WriteLine("Try to connect!");

            // Wait for a connection.
            var listener = new TcpListener(IPAddress.Parse("192.168.1.78"), 5900); listener.Start();
            
            while (true)
            {
                var client = listener.AcceptTcpClient();

                // Set up a framebuffer and options.
                var options = new VncServerSessionOptions();
                options.AuthenticationMethod = AuthenticationMethod.Password;

                // Create a session.
                Session = new VncServerSession();
                Session.MaxUpdateRate = 30;
                Session.Connected += HandleConnected;
                Session.ConnectionFailed += HandleConnectionFailed;
                Session.Closed += HandleClosed;
                Session.PasswordProvided += HandlePasswordProvided;
                //Session.SetFramebufferSource(VncScreenFramebufferSource());
                Session.SetFramebufferSource(new VncScreenFramebufferSource("Hello World", Screen.PrimaryScreen));
                Session.Connect(client.GetStream(), options);
            }

        }
    }
}
