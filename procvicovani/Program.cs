using System;
using System.Collections.Generic;
using System.Linq;

namespace Tridy_procvicovani
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Zadejte jméno studenta (nebo 'exit' pro ukončení):");
                string jmeno = Console.ReadLine();
                if (jmeno.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }

                Student student = new Student(jmeno);

                Console.WriteLine("Zadejte 5 známek (1-5):");
                for (int i = 0; i < 5; i++)
                {
                    student.PridatZnamku();
                }

                Console.WriteLine("Chcete přidat dalšího studenta? (ano/ne)");
                string odpoved = Console.ReadLine().ToLower();
                if (odpoved == "ne")
                {
                    break;
                }
            }

            Console.WriteLine("\nCelkový počet studentů: " + Student.PocetStudentu());
            Student.ZobrazitJmena();
            Student.ZobrazitPrumer();

            Console.ReadKey();
        }
    }

    public class Student
    {
        public string Jmeno { get; private set; }
        private List<int> znamky;
        private static List<Student> seznamStudentu = new List<Student>();

        public Student(string jmeno)
        {
            Jmeno = jmeno;
            znamky = new List<int>();
            seznamStudentu.Add(this);
        }

        public void PridatZnamku()
        {
            bool platnyVstup = false;
            while (!platnyVstup)
            {
                try
                {
                    int znamka = Convert.ToInt32(Console.ReadLine());
                    if (znamka >= 1 && znamka <= 5)
                    {
                        znamky.Add(znamka);
                        platnyVstup = true;
                    }
                    else
                    {
                        Console.WriteLine("Známka musí být v rozmezí 1-5. Zadejte znovu:");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Neplatný vstup, zadejte číslo mezi 1-5:");
                }
            }
        }

        public static int PocetStudentu()
        {
            return seznamStudentu.Count;
        }

        public static void ZobrazitJmena()
        {
            Console.WriteLine("\nJména všech studentů:");
            foreach (var student in seznamStudentu)
            {
                Console.WriteLine("- " + student.Jmeno);
            }
        }

        public static void ZobrazitPrumer()
        {
            Console.WriteLine("\nPrůměry všech studentů:");
            foreach (var student in seznamStudentu)
            {
                if (student.znamky.Count > 0)
                {
                    Console.WriteLine(student.Jmeno + ": " + student.znamky.Average().ToString("0.00"));
                }
                else
                {
                    Console.WriteLine(student.Jmeno + ": Nemá žádné známky.");
                }
            }
        }
    }
}
