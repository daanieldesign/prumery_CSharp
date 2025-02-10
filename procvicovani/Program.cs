using System;
using System.Collections.Generic;
using System.Linq;

namespace Tridy_procvicovani
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vytvoření nového studenta
            Console.WriteLine("Zadejte jméno studenta");
            Student s1 = new Student();
            s1.Jmeno = Console.ReadLine();

            Student s2 = new Student();
            Student s3 = new Student();

            Console.WriteLine("Zadejte 5 známek");
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    s1.AddGrade(Convert.ToInt32(Console.ReadLine()));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Něco se pokazilo při zadávání známek");
            }

            s1.KontrolaPrumeru();

            Console.WriteLine("Počet studentů: " + Student.seznamStudentu.Count);

            Student.DisplayStudentNames();

            s1.ModifyGrade(2, 5);

            Student.DisplayStudentNames();

            Console.ReadKey();
        }
    }

    public class Student
    {
        public string Jmeno;
        public double PrumernaZnamka;
        public List<int> znamky;
        public static List<Student> seznamStudentu = new List<Student>();

        public Student()
        {
            znamky = new List<int>(); 
            seznamStudentu.Add(this);
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
            catch (Exception)
            {
                Console.WriteLine("Něco se pokazilo při výpočtu průměru");
            }
        }

        public void AddGrade(int grade)
        {
            znamky.Add(grade); 
        }

        public static void DisplayStudentNames()
        {
            Console.WriteLine("Jména všech studentů:");
            foreach (var student in seznamStudentu)
            {
                Console.WriteLine(student.Jmeno);
            }
        }

        public void ModifyGrade(int index, int newGrade)
        {
            if (index >= 0 && index < znamky.Count)
            {
                znamky[index] = newGrade;
                Console.WriteLine("Známka na pozici " + index + " byla upravena na " + newGrade);
            }
            else
            {
                Console.WriteLine("Neplatný index.");
            }
        }
    }
}