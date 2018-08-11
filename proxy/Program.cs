using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proxy
{
    class Program
    {
        public interface IServer
        {
            void ProcessRequest();
        }

        public class GoogleServer : IServer
        {
            private string Url;
            public GoogleServer(string url)
            {
                Url = url;

                Connecting();
            }
            
            public void ProcessRequest()
            {
                Console.WriteLine("process request "+Url);
            }

            private void Connecting()
            {
                Console.WriteLine("Connecting to "+Url);
            }
        }

        public class Proxy : IServer
        {
            private string Url;
            private GoogleServer googleServer;

            public Proxy(string url)
            {
                Url = url;
            }

            public void ProcessRequest()
            {
                if (googleServer == null)
                {
                    googleServer = new GoogleServer(Url);
                }

                string[] credentials = Url.Split(new string[] { "username=","password="},StringSplitOptions.RemoveEmptyEntries);

                string username = credentials[1];
                string password = credentials[2];

                if (username == "admin" && password == "password")
                {
                    Console.WriteLine("Connecting to " + Url);
                }
                else
                {
                    Console.WriteLine("connection trouble");
                }
            }
        }

        static void Main(string[] args)
        {
            IServer googleServer = new GoogleServer("https://www.google.com/username=admin&password=pass");
            googleServer.ProcessRequest();
            Console.ReadKey();
        }
    }
}
