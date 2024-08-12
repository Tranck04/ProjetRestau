using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MultiClient
{
    public class Program
    {
        private static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private const int PORT = 100;

        static Thread Connect1, Connect2, Request;

        public static void Main()
        {
            
            Console.Title = "Cuisine";

            Connect1 = new Thread(ConnectToServer);
            Connect2 = new Thread(ConnectToServer);

            //Request = new Thread(RequestLoop);

            Connect1.Start();

            //Connect2.Start();

            //Request.Start(); 
            //ConnectToServer();

            RequestLoop();
            Exit();
        }

        private static void ConnectToServer()
        {

            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine("Nombre de tentatives de connexion : " + attempts);
                    ClientSocket.Connect(IPAddress.Loopback, PORT);
                }
                catch (SocketException)
                {
                    Console.Clear();
                }
            }

            Console.Clear();
            Console.WriteLine("Connecté.");
        }

        private static void RequestLoop()
        {
            string nom = null;
            while (true)
            {
                SendRequest(nom);
                ReceiveResponse();
            }
        }

        /// Ferme le programme.

        private static void Exit()
        {
            SendString("Fermeture de connexion.");
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
            Environment.Exit(0);
        }

        private static void SendRequest(string nom)
        {
            Person person1 = new Person("Beubeu", 20, true);

            nom = Console.ReadLine() + " : ";

            Console.Write("Envoie d'une requête de " + person1.Name + " : ");

            while (true)
            {
                string request = Console.ReadLine();
                //SendString(nom + request);

                if (person1.Try == true)
                {
                    SendString(nom + person1.Name + " (" + person1.Age + ") " + request);
                }
                /*if (request.ToLower() == "Exit")
                {
                    Exit();
                }*/
            }
        }

        /// Envoie une chaîne de caractère encodée en ASCII.

        private static void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private static void ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            Console.WriteLine(text);
        }


    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Try { get; set; }
        public Person(string name, int age, bool _try)
        {
            Name = name;
            Age = age;
            Try = _try;
        }
    }
}
