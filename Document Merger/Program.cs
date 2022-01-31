using System;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Console.WriteLine("Document Merger");
            string fileOne = GetFileNames();
            while(CheckFile(fileOne))
            {
                break;
            }
            string fileTwo = GetFileNames();
            while(CheckFile(fileTwo)) //need to implement the read functino somewhere in here
            {
                
                MergeFiles(fileOne,fileTwo);
                break;
            }
            //Ask if they would like to do again
            Console.WriteLine("Would you like to do this again? \nEnter y / n");
            string redo = Console.ReadLine();
            if(redo == "y")
            {
                doAgain();
            }
            else
            {
                Console.WriteLine("Thank you for using the program!");
            }
        }
        static string CheckFileName(string fileName) //Function to check file names
        {
            if(fileName.EndsWith(".txt"))
            {
                return fileName;
            }
            else
            {
                fileName = fileName + ".txt";
                return fileName;
            }
        }
        static string GetFileNames()
        {
            string fileName = "";
            Console.WriteLine("Please enter the name of your file: ");
            fileName = Console.ReadLine();
            fileName = CheckFileName(fileName);
            return fileName;
        }

        static bool CheckFile(string fileName) //Checking to see if file exist
        {   bool x = true;
            if(File.Exists(fileName))
            {
                x = true;
                
            }
            else
            {
                x = false;
                Console.WriteLine("File Does Not Exist Please Try Again");
                fileName = null;
                GetFileNames();
            }
            return x;
        }

        static void MergeFiles(string file1, string file2)
        {
            Console.WriteLine(file1,file2);
            try
            {
            
            string[]fileOne = File.ReadAllLines(file1);
            string[]fileTwo = File.ReadAllLines(file2);
            String merged = file1.Substring(0,file1.Length-4)+file2.Substring(0,file2.Length-4)+".txt";;
            
            
            
            using (StreamWriter writer = File.CreateText(merged))//does not work
            {
                int lineNum = 0;
                while(lineNum < fileOne.Length || lineNum < fileTwo.Length)
                {
                    if(lineNum < fileOne.Length)
                        writer.WriteLine(fileOne[lineNum]);
                    if(lineNum < fileTwo.Length)
                        writer.WriteLine(fileTwo[lineNum]);

                        lineNum++;
      
                }
            }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Completed!");
                
            }

        }
        static void doAgain()
        {
            Console.WriteLine("Document Merger");
            string fileOne = GetFileNames();
            while(CheckFile(fileOne))
            {
                break;
            }
            string fileTwo = GetFileNames();
            while(CheckFile(fileTwo)) //need to implement the read functino somewhere in here
            {
                
                MergeFiles(fileOne,fileTwo);
                break;
            }
        }
    }

}

 