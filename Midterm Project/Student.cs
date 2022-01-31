using System;
using System.Collections.Generic;

namespace Midterm_Project
{

    public enum StudentClass{freshman, sophmore, junior, senior} //students category
    class Student : Person
    {
        //Instance variables
        private string major;
        private int creditHours;

        public Student(string firstName,string lastName, string id, string major, int creditHours) : base(firstName, lastName, id, Category.student)
        {
            this.major = major;
            this.creditHours = creditHours;
        }
         public void updateCreditHours(int hours) //update credit hour function
        {
            this.creditHours += hours;
        }
        public int getCreditHours() //returning amount 
        {
            return this.creditHours;
        }
       
        public StudentClass getStudentClass()
        {

            if(creditHours <= 29)
            {
            return StudentClass.freshman;
            }
            else if(creditHours >= 30 && creditHours <= 59)
            {
            return StudentClass.sophmore;
            }
            else if(creditHours >= 60 && creditHours <= 89)
            {
            return StudentClass.junior;
            }
            else if((creditHours >= 90))
            {
                return StudentClass.senior;
            }
            return StudentClass.senior;

            
            
        
        }


    }
}