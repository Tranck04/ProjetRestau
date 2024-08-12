using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    public class Pool
    {
        public static void Main(string[] args)
        {
            string[] EmploiNomC = { "Serveur 1 Carré 1", "Serveur 2 Carré 1", "Serveur 1 Carré 2", "Serveur 2 Carré 2", "Maître d'hôtel", "Commis de salle", "Chef de Rang Carré 1", "Chef de Rang Carré 2",
                "Chef de cuisine", "Chef de Partie 1", "Chef de Partie 2", "Commis de cuisine", "Plongeur"};
            string[] EmploiNom = { "s1c1", "s2c1", "s1c2", "s2c2", "MH", "CS", "CRC1", "CRC2", "CdP1", "CdP2", "CdC", "CC", "P" };
            Thread[] Emploi = new Thread[12];

            Console.WriteLine("Le service a commencé. ");

            for (int i = 0; i < EmploiNom.Length; i++)
            {
                
                Thread Test = new Thread(new ThreadStart(Fonc));
                Test.Name = EmploiNom[i];

                Test.Start();
                Console.WriteLine("L'état du thread " + Test.Name + " est : " + Test.ThreadState);

                string Test2 = Console.ReadLine();

                if (Test.Name == "s1c2" && Test.ThreadState == ThreadState.Running)
                { 
                    int worker = 0;
                    int io = 0;

                    ThreadPool.QueueUserWorkItem(Bloc);
                    Thread.Sleep(1000);

                    ThreadPool.GetAvailableThreads(out worker, out io);
                    Console.WriteLine("\nThread Worker {0:N0}", worker);
                    Console.WriteLine("Asynchronous {0:N0}\n", io);
                }

                if ((Test.Name == "s2c2" && Test.ThreadState == ThreadState.Running))
                {
                    int worker = 0;
                    int io = 0;

                    ThreadPool.QueueUserWorkItem(Bloc);
                    Thread.Sleep(1000);

                    ThreadPool.GetAvailableThreads(out worker, out io);
                    Console.WriteLine("\nThread Worker {0:N0}", worker);
                    Console.WriteLine("Asynchronous {0:N0}\n", io);
                }

                /*if ((Test.Name == "s2c2" && Test.ThreadState == ThreadState.Running)) 
                {
                    ThreadPool.QueueUserWorkItem(Bloc);
                    Thread.Sleep(1000);
                }*/

                /*for (int j = 0; j < EmploiNom.Length; j++)
                {

                    
                    if ((Test.Name == "s1c2" && Test.ThreadState == ThreadState.Running)) //&& (Test.Name == "s2c2" && Test.ThreadState == ThreadState.Running))
                    {
                        ThreadPool.QueueUserWorkItem(Bloc);
                        Thread.Sleep(100);
                    }
                    

                        
                        if (Test.ThreadState == ThreadState.Unstarted)
                        {
                            Test.Start();
                        }
                        

                        /
                        else if (Test2 == "1")
                        {
                            /*Test = null;
                            Test = new Thread(new ThreadStart(Fonc));
                            Test.Abort();   
                        }
                        
                    }*/

                Test.Abort();
                Console.WriteLine("L'état du thread " + Test.Name + " est : " + Test.ThreadState +"\n");

            }

            /*
            if (Test.ThreadState == ThreadState.Running)
            {
                string State = "Action en cours.";
                Console.WriteLine(EmploiNomC[i] + " : " + State);
            }
            else if (Test.ThreadState == ThreadState.Aborted || Test.ThreadState == ThreadState.AbortRequested)
            {
                string State = "Disponible.";
                Console.WriteLine(EmploiNomC[i] + " : " + State);
            }
            */

        }

            static void Bloc(Object stateInfo)
        {
            Console.WriteLine("Thread secondaire en cours.");
            
        }

            public static void Fonc()
            {
                while (true)
                {

                }
            }
    }
}

        /*
        public class Convert
        {
            private Thread _Test;

            public Convert(Thread nomTest)
            {
                Thread _Test = nomTest;
            }
        }
        */

     /*
     public static void EtatThread(string position)
     {
        Console.WriteLine("" + position);
        Console.WriteLine("-------------- Salle -------------- \n");
        Console.WriteLine("Serveur 1 Carré 1    |\t" + s1c1.ThreadState);
        Console.WriteLine("Serveur 2 Carré 1    |\t" + s2c1.ThreadState);
        Console.WriteLine("Serveur 1 Carré 2    |\t" + s1c2.ThreadState);
        Console.WriteLine("Serveur 2 Carré 2    |\t" + s2c2.ThreadState);
        Console.WriteLine("Maître d'hôtel       |\t" + MH.ThreadState);
        Console.WriteLine("Commis de Salle      |\t" + CS.ThreadState);
        Console.WriteLine("Chef de Rang Carré 1 |\t" + CRC1.ThreadState);
        Console.WriteLine("Chef de Rang Carré 2 |\t" + CRC2.ThreadState);
        Console.WriteLine("\n");
        Console.WriteLine("------------- Cuisine ------------- \n");
        Console.WriteLine("Chef de Cuisine      | \t" + CdC.ThreadState);
        Console.WriteLine("Cuisinier 1          | \t" + CdP1.ThreadState);
        Console.WriteLine("Cuisinier 2          | \t" + CdP2.ThreadState);
        Console.WriteLine("Commis cuisine       | \t" + CC.ThreadState);
        Console.WriteLine("Plongeur             | \t" + P.ThreadState);

    }
    */

        /*
        s1c1 = new Thread(Fonc);
        s2c1 = new Thread(Fonc);
        s1c2 = new Thread(Fonc);
        s2c2 = new Thread(Fonc);
        MH = new Thread(Fonc);
        CS = new Thread(Fonc);
        CRC1 = new Thread(Fonc);
        CRC2 = new Thread(Fonc);
        CdC = new Thread(Fonc);
        CdP1 = new Thread(Fonc);
        CdP2 = new Thread(Fonc);
        CC = new Thread(Fonc);
        P = new Thread(Fonc);

        EtatThread("");

        s1c1.Start();
        s2c1.Start();
        s1c2.Start();
        s2c2.Start();
        MH.Start();
        CS.Start();
        CRC1.Start();
        CRC2.Start();
        CdC.Start();
        CdP1.Start();
        CdP2.Start();
        CC.Start();

        if (CC.ThreadState == 0)
        {
            P.Start();
            CC.Abort();
        }

        EtatThread("");
        */




