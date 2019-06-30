using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {

            float[] studentMarks; // float Array to store Student marks
            string[] studentNames; // string Array to store Student names 
            String[] studentRating; // string array to store rating results for the students
            int num=0; // int num store the number of students
            string value;
            do { // ReadLine store it in value variable ,if it's a positive Number parse it to num variable if not tray again
                Console.Write("Enter the Number of Students : ");
                value = Console.ReadLine();
                if (int.TryParse(value, out num) && num > 0){}
                else{ Console.WriteLine("\nERORR, Please Enter Positive Numbers Only .."); }
            } while (num<=0);

            studentMarks = new float[num]; 
            studentNames = new string[num];
            studentRating = new string[num];
            Boolean isAcceptableNum; // boolean isAcceptableNum to check if it's an Acceptable Number

            for (int i = 0; i < num; i++)
            {// for loop reads the name of th student and there marks and get the rate for every student 
                Console.WriteLine("What is the Name of Your Student Number (" + (i + 1) + ")? ");
                studentNames[i] = Console.ReadLine(); // read the Student name and store it in studentNames Array index = [i]
                Console.WriteLine("What is " + studentNames[i] + "'s Mark: ");
                do
                {
                    /* checks if the entered mark is positve number between 0 and 100 if it's an Acceptable Number it will store in studentMarks[i] 
                     and check what grade the Student gots and store it to studentRating[i] */
                    value = Console.ReadLine();
                    if (float.TryParse(value, out studentMarks[i]) && studentMarks[i] >=0 && studentMarks[i] <= 100){
                        isAcceptableNum = true;
                        if (studentMarks[i] < 50.00)  studentRating[i] = "Failed"; 
                        else if (studentMarks[i] < 60.00)  studentRating[i] = "Acceptable"; 
                        else if (studentMarks[i] < 70.00)  studentRating[i] = "Good"; 
                        else if (studentMarks[i] < 80.00)  studentRating[i] = "Very good"; 
                        else if (studentMarks[i] < 90.00)  studentRating[i] = "Excellent"; 
                        else if (studentMarks[i] <= 100.00)  studentRating[i] = "Honor"; 
                    }
                    else
                    {// if it's not an Acceptable Number it will print an Error and ask you to tray again
                        isAcceptableNum = false;
                        Console.WriteLine("\nERORR, Please  Enter a Number Between 0 and 100\nEnter "+studentNames[i]+"'s Mark Again: ");
                    }
                } while (!isAcceptableNum);
                Console.Write("\n");
            }
            Console.WriteLine("Press Any Key to Display The Results....");
            Console.ReadKey();
            Console.Clear();


            //print the Results 
            Console.WriteLine("*********************************************");
            Console.WriteLine("|           Name          | Mark |   grade  |");
            Console.WriteLine("|*************************|******|**********|");
            for (int i = 0; i < num; i++)
            {
                Console.Write("|{0, -25}|", studentNames[i]);
                Console.Write("{0, -6}|", studentMarks[i]);
                Console.Write("{0, -10}|", studentRating[i]);
                Console.WriteLine();
            }
            Console.WriteLine("*********************************************\n");

            Console.WriteLine("********************");
            Console.WriteLine("|     results      |");
            Console.WriteLine("********************");
            Console.WriteLine("|averge  | {0,-8}|" , average(studentMarks));
            Console.WriteLine("|failures| {0,-8}|", failures(studentRating));
            Console.WriteLine("|Sucssed | {0,-8}|", successfull(studentRating));
            Console.WriteLine("|honors  | {0,-8}|", honors(studentRating));
            Console.WriteLine("********************");



            Console.ReadKey();

        }

        static float average (float[] studentMarks)
        { // average method takes a float array as a parameter 
            float mid = 0;
            for (int i = 0; i < studentMarks.Length; i++)
            {// sum the marks array elements 
                mid += studentMarks[i];
            }

            return mid /= studentMarks.Length; // average method return the average of the marks array elements
        }

        static int failures(string[] studentRating)
        {// failures  method takes a string array as a parameter
            int failures = 0;
            for (int i = 0; i < studentRating.Length; i++)
            { // count the number of failures  in studentsRating array
                if (studentRating[i].Equals("Failed"))
                {
                    failures++;
                }
            }
            return failures; // failures  method returns the number of failours
        }
        static int honors(string[] studentRating)
        {// honors method takes a string array as a parameter
            int honors = 0;
            for (int i = 0; i < studentRating.Length; i++)
            { // count the number of honors in studentsRating array
                if (studentRating[i].Equals("Honor"))
                {
                    honors++;
                }
            }
            return honors;// honors method returns the number of honors

        }
        static int successfull(string[] studentsRating)
        {// successfull method takes a string array as a parameter
            int successfull = 0;
            for (int i = 0; i < studentsRating.Length; i++)
            { // count the number of successfull in studentsRating array
                if (!(studentsRating[i].Equals("Failed")))
                {
                    successfull++;
                }
            }
            return successfull; // successfull method returns the number of successfull
        }
    }
}
