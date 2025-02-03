using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tridy_procvicovani
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte jméno studenta: ");
            Student s1 = new Student();
            s1.Jmeno = Console.ReadLine();
            Student s2 = new Student();
            Student s3 = new Student();
            Console.WriteLine("Zadejte 5 známek: ");
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    s1.znamky.Add(Convert.ToInt32(Console.ReadLine()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Něco se pokazilo.");
            }

            s1.KontrolaPrumeru();
            Console.WriteLine("počet studentů: " + Student.seznamStudentu);
            Console.ReadKey();
            // - přidání známky přepište na vlastní metodu (v rámci třídy)

        }
    }
    public class Student
    {
        public string Jmeno;
        public double PrumernaZnamka;
        public List<int> znamky;
        public static int seznamStudentu;
        public Student()
        {
            znamky = new List<int>();
            seznamStudentu++;
        }

        public void Znamky()
        {
            Console.WriteLine("Zadejte 5 známek: ");
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    znamky.Add(Convert.ToInt32(Console.ReadLine()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Něco se pokazilo.");
            }
        }


        public void ZobrazInfo()
        {
            Console.WriteLine("Jméno studenta: " + Jmeno + "\nJeho průměr: " + PrumernaZnamka);
        }
        public void KontrolaPrumeru()
        {
            try
            {
                double prumer = znamky.Average();
                if (prumer < 1.5)
                {
                    Console.WriteLine("Student má nárok na stipendium.");
                }
                else
                {
                    Console.WriteLine("Student nemá nárok na stipendium.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Něco se pokazilo.");
            }
        }
    }
}