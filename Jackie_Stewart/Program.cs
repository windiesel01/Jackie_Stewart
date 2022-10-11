using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackie_Stewart
{
    internal class Program
    {
        class Statisztika
        {
            int year, races, wins, podiums, fastests;

            public int Year { get => year; set => year = value; }
            public int Races { get => races; set => races = value; }
            public int Wins { get => wins; set => wins = value; }
            public int Podiums { get => podiums; set => podiums = value; }
            public int Fastests { get => fastests; set => fastests = value; }

            public Statisztika(int year, int races, int wins, int podiums, int fastests)
            {
                Year = year;
                Races = races;
                Wins = wins;
                Podiums = podiums;
                Fastests = fastests;
            }

            public Statisztika(string adatsor)
            {
                string[] adatok = adatsor.Split('\t');
                Year = int.Parse(adatok[0]);
                Races = int.Parse(adatok[1]);
                Wins = int.Parse(adatok[2]);
                Podiums = int.Parse(adatok[3]);
                Fastests = int.Parse(adatok[4]);
            }
        }

        static void Main(string[] args)
        {
            List<Statisztika> lista = new List<Statisztika>();

            using (StreamReader beolvasas = new StreamReader("jackie.txt", Encoding.UTF8))
            {
                beolvasas.ReadLine();
                while (!beolvasas.EndOfStream)
                {
                    lista.Add(new Statisztika(beolvasas.ReadLine()));
                }
            }

            Console.WriteLine($"3. feladat: {lista.Count}");

            Console.WriteLine($"4. feladat: {lista.First(x => x.Races == lista.Max(y => y.Races)).Year}");

            Console.WriteLine($"5. feladat:\n\r\t70-as évek {lista.Where(x => x.Year >= 1970 && x.Year < 1980).Sum(y => y.Wins)} megnyert verseny \n\r\t60-as évek {lista.Where(x => x.Year >= 1960 && x.Year < 1970).Sum(y => y.Wins)} megnyert verseny");

            using (StreamWriter html = new StreamWriter("jackie.html", false, Encoding.UTF8))
            {
                html.WriteLine("<!DOCTYPE html>");
                html.WriteLine("<html lang=\"hu-HU\">");
                html.WriteLine("\t<head><style>td{border: solid 1px #000;}</style></head>");
                html.WriteLine("\t<body>");
                html.WriteLine("\t\t<h1>Jackie Stewart</h1>");
                html.WriteLine("\t\t<table border=\"1px\">");
                html.WriteLine("\t\t\t<tbody>");
                foreach (Statisztika item in lista.OrderByDescending(x => x.Year))
                {
                    html.WriteLine($"\t\t\t\t<tr><td>{item.Year}</td><td>{item.Races}</td><td>{item.Wins}</td></tr>");
                }
                html.WriteLine("\t\t\t</tbody>");
                html.WriteLine("\t\t</table>");
                html.WriteLine("\t</body>");
                html.WriteLine("</html>");
            }
            Console.WriteLine("6. feladat: jackie.html");

            Console.ReadKey();
        }
    }
}
