﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tärningspel
{
    //Det här programmet visar hur man med högst sannoilikhet får 30 poäng eller över. 
    //Tre metoder har gjorts i tre olika projekt. Denna projektet visar en metod,
    //denna metoden är att spara 6:or och 5.or  och om inte finns: välj högsta. 
    //Summan i slutet av koden visar dig hur många som blev 30 och över. 
    
    
    class Program
    {
        static Random random;
        static int over30 = 0; 
        static void Main(string[] args)
        {
            random = new Random();
            List<int> Dices = new List<int>();      //Ny lista dices
            for (int a = 0; a < 10000; a++)         //Gör om applikationen så många gånger (Antal rundor spelade)                      
            {                   
                Dices.Clear();                      //rensa dices                     

                for (int i = 0; i < 6; i++)         //För 6 olika tärningar..:
                {
                    Dices.Add(random.Next(1, 7));   //randomisera 6 tärningar
                }
                //Console.WriteLine("Osorterad lista");
                //printList(Dices);
                Dices.Sort();       // Sortera
                Dices.Reverse();
               // printList(Dices);// Omvänd sortering
                                    // Dices.Remove(0);
                                    // Console.WriteLine("Sorterad lista");
                                    // printList(Dices);

                int r = method2(Dices);  // Gör om metod dices till r
                Console.WriteLine(r);
                if (r >= 30)             // Om summan 30 eller mer:
                {
                    over30++;           // Lägg ihop alla summor som är >= 30
                }
                    
                
            }
            Console.WriteLine(over30);
            Console.ReadLine();
        }

        
        // Lägg till alla 6 och 5
        public static int  method2(List<int> dices)
        {
            List<int> collectedDices = new List<int>();         // Ny lista collectedDices med "Klara tärningar".
            while (dices.Count > 0)
            {
                // Om det finns 6 eller 5
                if (dices[0] == 6 || dices[0] == 5)
                {
                    foreach (int d in dices.ToList())


                    {
                        // Lägg till 6 och 5
                        if (d == 6 || d == 5)
                        {
                            collectedDices.Add(d);          // Lägg till i lista med klara tärningar.
                            dices.RemoveAt(0);              // Ta bort klara tärningar från dices.
                        }
                    }
                }
                // Annars lägg till högsta värdet
                else
                {
                    collectedDices.Add(dices[0]);
                    dices.RemoveAt(0);
                }
                // Console.WriteLine("Lista med slagna tärningar");
                //printList(dices);
                //Console.WriteLine("Klara tärningar");

                //printList(collectedDices);

                // Börja om
                for (int i = 0; i < dices.Count; i++)
                {
                    dices[i] = random.Next(1, 7);

                }

                dices.Sort();
                dices.Reverse();
            }

            return collectedDices.Sum();
            
          

        }

//        List<int> collectedDices = new List<int>();
//            while (dices.Count > 0)
//            {
//                // Om det finns 6 eller 5
//                if (dices[0] == 6 || dices[0] == 5)
//                {
//                    foreach (int d in dices.ToList())


//                    {
//                        // Lägg till 6 och 5
//                        if (d == 6 || d == 5)
//                        {
//                            collectedDices.Add(d);
//                            dices.RemoveAt(0);
//                        }
//}
//                }
//                // Annars lägg till högsta värdet
//                else
//                {
//                    collectedDices.Add(dices[0]);
//                    dices.RemoveAt(0);
//                }





        //// Private
        //public static void printList(List<int> l)
        //{
        //    for (int i = 0; i < l.Count; i++)
        //    {
        //        {
        //            Console.WriteLine(l[i] + "-----");
        //        }
        //    }
        //}








    }
}
