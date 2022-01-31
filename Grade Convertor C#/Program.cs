using System;
using System.Collections.Generic;

namespace Grade_Convertor_C_
{
    class Program
    {

        static float getGrades() //function to get the grade
        {
            float grade = 0;
            try
            {
            //Get user input
            Console.WriteLine("Please enter your grade: ");
            grade = float.Parse(Console.ReadLine());
            } catch(Exception) 
            {
                Console.WriteLine("Please enter a number.");
            }
            return grade;
        }
       
        static void Main(string[] args) //main function
        {
            //Greeting Messege
            Console.WriteLine("Please Enter Your First and Last Name: ");
            string user_name = Console.ReadLine();
            Console.WriteLine($"______________________________________________\nHello {user_name} Welcome to the Grade Converter!\n");
            
            //Get the Grade Amount
            int grade_amount = 0;
            try
            {
                Console.WriteLine("Enter the number of grades you need to convert: ");
                grade_amount = int.Parse(Console.ReadLine()); //grade_amount hold the number of grades value  
            }catch (Exception)
            {
                Console.WriteLine("Please enter a number.");
            }

            //Create a list to hold the grade variables
            List<float>grades = new List<float>();
            int i = 0;
            float grade_number;
            float sum = 0;

            //Create Loop to insert variables into the list
            while (i < grade_amount)
            {
                 grade_number = getGrades();
                 grades.Add(grade_number);
                 sum = sum + grade_number;
                 i++;

            }

             //Create a foreach to print out the grades
            foreach(float n in grades)
            {
                string grade_letter;
                if(n >= 90)
                {
                    grade_letter = "A";
                }
                else if (n >= 80 && n <= 89)
                {
                    grade_letter = "B";
                }
                else if (n >= 70 && n <= 79)
                {
                    grade_letter = "C";
                }
                else if (n >= 60 && n <= 69)
                {
                    grade_letter = "D";
                }
                else
                {
                    grade_letter = "F";
                }


            Console.WriteLine($"\nA score of {n} if a {grade_letter} grade. ");
      
            }

            //Finding Average Grade
            float average = 0;
            average = sum/grade_amount;
            string average_grade;

            //Find Grade Value of the Average
            if(average >= 90)
                {
                    average_grade = "A";
                }
                else if (average >= 80 && average <= 89)
                {
                    average_grade = "B";
                }
                else if (average >= 70 && average <= 79)
                {
                    average_grade = "C";
                }
                else if (average >= 60 && average <= 69)
                {
                    average_grade = "D";
                }
                else
                {
                    average_grade = "F";
                }
            
            Console.WriteLine("\nGrade Statistics\n-------------------\n");
            Console.WriteLine($"Number of grades {grade_amount}");
            Console.WriteLine($"Average Grade: {average} which is a {average_grade}");

        }
    }
}
