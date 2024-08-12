using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int Assiette = 150;
            int Fourchette = 150;
            int Couteau = 150;
            */

            int IU = 0;
            int IS = 150;
            int IP=0;

            var Client = new List<int> { };
            int[] ClientA = new int[15];
            int[] ClientS = new int[15];

            string Test;
            bool Test2;
            int Alea;
            Random rnd = new Random();
           

            while (IU < 150 && IS > 0)
            {
                /*Console.WriteLine("\nNombre de couverts en stock : " + IS);
                Console.WriteLine("Nombre de couverts utilisés en salle : " + IU);
                Console.WriteLine("Nombre de clients arrivés : ");
                Console.WriteLine("Combien de couverts sont à installer ?");*/

                for (int i=0; i<=14; i++)
                {

                    ClientA[i] = rnd.Next(1, 10);
                    IS = IS - ClientA[i];
                    IU = IU + ClientA[i];

                    if (IU >= 150)
                    {
                        IU = 150;

                        break;
                    }             

                    if (IU >= 150 && IS <= 0)
                 
                    {
                        Console.WriteLine("Plus assez de couverts pour un tel nombre de client !");
                    }
                    else
                    {
                        Console.WriteLine("Nombre de couverts utilisés en salle : " + IU);
                        Console.WriteLine("\nNombre de couverts en stock : " + IS);
                    }

                    Console.WriteLine("Nombre de clients arrivés : " + ClientA[i]);

                    if ((i % 3) != 1)
                    {
                        ClientS[i] = rnd.Next(1, 10);

                        IS = IS + ClientS[i];

                        if (IS > 150)
                        {
                            IS = 150;
                        }

                        IU = IU - ClientS[i];


                        if (IU < 0)
                        {
                            IU = 0;
                        }

                      
                    }

                    Console.WriteLine("Nombre de clients partis : " + ClientS[i]);

                    Test = Console.ReadLine();
                }
            }

            Console.WriteLine("Impossible d'accueillir plus de clients pour le moment.");
            Console.ReadLine();

        }
    }
}



/*Test = Console.ReadLine();
Test2 = int.TryParse(Test, out IP);

if(IP <= 10)
{
    Client.Add(IP);
}
else
{
    Console.WriteLine("Impossible d'accueillir autant de personnes sur une même tâble.");
}


foreach (int element in Client)
{
    IU = IU + element;
    IS = IS - element;
    Client = new List<int> {};
}*/

//IS = IS - IP;
//IU = IU + IP;


