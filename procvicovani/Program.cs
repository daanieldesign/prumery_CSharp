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
                Console.WriteLine("Zadejte jméno studenta:");
                string jmeno = Console.ReadLine();
                if (jmeno.ToLower() == "exit")
                    break;

                Student student = new Student();
                student.Jmeno = jmeno;

                Console.WriteLine("Zadejte 5 známek:");
                for (int i = 0; i < 5; i++)
                {
                    bool validInput = false;
                    while (!validInput)
                    {
                        try
                        {
                            int grade = Convert.ToInt32(Console.ReadLine());
                            if (grade >= 1 && grade <= 5)
                            {
                                student.AddGrade(grade);
                                validInput = true;
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
            }

            Console.WriteLine("Počet studentů: " + Student.GetStudentCount());
            Student.JmenaStudenti();
            Student.VsechnyPrumery();
            Console.ReadKey();
        }
    }

    public class Student
    {
        public string Jmeno;
        public List<int> znamky;
        public static List<Student> seznamStudentu = new List<Student>();

        public Student()
        {
            znamky = new List<int>();
            seznamStudentu.Add(this);
        }

        public void KontrolaPrumeru()
        {
            if (znamky.Count == 0)
            {
                Console.WriteLine("Student nemá žádné známky.");
                return;
            }

            double prumer = znamky.Average();
            if (prumer < 1.5)
            {
                Console.WriteLine("Student " + Jmeno + " má nárok na stipendium.");
            }
            else
            {
                Console.WriteLine("Student " + Jmeno + " nemá nárok na stipendium.");
            }
        }

        public void AddGrade(int grade)
        {
            znamky.Add(grade);
        }

        public static void JmenaStudenti()
        {
            Console.WriteLine("Jména všech studentů:");
            foreach (var student in seznamStudentu)
            {
                Console.WriteLine(student.Jmeno);
            }
        }

        public void ModifyGrade(int index, int newGrade)
        {
            if (index >= 0 && index < znamky.Count && newGrade >= 1 && newGrade <= 5)
            {
                znamky[index] = newGrade;
                Console.WriteLine("Známka na pozici " + index + " byla upravena na " + newGrade);
            }
            else
            {
                Console.WriteLine("Neplatný index nebo známka.");
            }
        }

        public void ResetGrades()
        {
            znamky.Clear();
            Console.WriteLine("Všechny známky studenta " + Jmeno + " byly smazány.");
        }

        public static int GetStudentCount()
        {
            return seznamStudentu.Count;
        }

        public static void VsechnyPrumery()
        {
            Console.WriteLine("Průměry všech studentů:");
            foreach (var student in seznamStudentu)
            {
                if (student.znamky.Count > 0)
                {
                    Console.WriteLine(student.Jmeno + ": " + student.znamky.Average());
                }
                else
                {
                    Console.WriteLine(student.Jmeno + ": Nemá žádné známky.");
                }
            }
        }
    }
}
