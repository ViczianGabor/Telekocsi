using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telekocsi
{
    class Program
    {

        static List<Auto> autok = new List<Auto>();
        static List<Igeny> igenyek = new List<Igeny>();
        static List<string> masodikk = new List<string>();
        static void AutokBeolvasas()
        {
            StreamReader sr = new StreamReader("autok.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                autok.Add(new Auto(sr.ReadLine()));


            }

            sr.Close();
        }



        static void IgenyekBeolvasas()
        {
            StreamReader sr2 = new StreamReader("igenyek.csv");
            sr2.ReadLine();
            while (!sr2.EndOfStream)
            {
                igenyek.Add(new Igeny(sr2.ReadLine()));
            }
            sr2.Close();
        }


        static void masodik()
        {
            Console.WriteLine(autok.Count());


           

        }

        static void harmadik()
        {
            int ferohely = 0;
            foreach (var item in autok)
            {
                if (item.Indulas == "Budapest" && item.Cel == "Miskolc")
                {
                    ferohely =+ item.Ferohely;
                }
            }
            Console.WriteLine(ferohely);
        }


        static void negyedik()
        {
            int max = autok[0].Ferohely;
            int index = 0;
            for (int i = 0; i < autok.Count; i++)
            {
                if (max <= autok[i].Ferohely)
                {
                    max = autok[i].Ferohely;
                    index = i;
                }
            }

            foreach (var item in autok)
            {
                if (item.Ferohely == max)
                {
                    Console.WriteLine($"A legtöbb férőhelyet ({max}-ot) a(z) {item.Indulas}-{item.Cel} útvonalon ajánlották fel a hirdetők");
                }
            }
            



            

        }


        static void otodik()
        {
            for (int i = 0; i < autok.Count; i++)
            {
                for (int j = 0; j < igenyek.Count; j++)
                {
                    if (autok[i].Indulas == igenyek[j].Indulas && autok[i].Cel == igenyek[j].Cel && autok[i].Ferohely > igenyek[j].Szemelyek)
                    {
                        Console.WriteLine($"\t{igenyek[j].Azonosito} => {autok[i].Rendszam}");
                    }
                }

            }


        }


        static void hatodik()
        {
            StreamWriter sw = new StreamWriter("utasuzenetek.txt");
            for (int i = 0; i < igenyek.Count; i++)
            {
                for (int j = 0; j < autok.Count; j++)
                {
                    if (autok[j].Indulas == igenyek[i].Indulas && autok[j].Cel == igenyek[i].Cel)//&& autok[j].Ferohely > igenyek[i].Szemelyek
                    {
                        sw.WriteLine($"{igenyek[i].Azonosito}: Rendszám:{autok[j].Rendszam}, Telefonszám:{autok[j].Telefonszam}");
                    }
                    
                }
                
                
                    sw.WriteLine($"{igenyek[i].Azonosito}: Sajnos nem sikerült autót találni");
                

            }

            sw.Close();
        }
        static void Main(string[] args)
        {
            AutokBeolvasas();
            IgenyekBeolvasas();
            masodik();
            harmadik();
            negyedik();
            otodik();
            hatodik();
            Console.ReadKey();

        }
    }
}
