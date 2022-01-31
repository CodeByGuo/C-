using System;
using System.Collections.Generic;

namespace Midterm_Project
{
    class Professor : Person
    {
        //Instance variables
        private string department;
        private string researchArea;

        //construstor
        public Professor(string firstName,string lastName, string id, string department, string researchArea) : base(firstName, lastName, id, Category.faculty)
        {
            this.department = department;
            this.researchArea = researchArea;
        }

        public string getDepartment() //returns department
        {
            return this.department;
        }

        public string setDepartment(string dept) //sets the department
        {
            this.department = dept;
            return this.department;
        } 
        public string getResearchArea() //gets the researchArea 
        {
            return this.researchArea;
        } 
        public string setResearchArea(string area) //sets the research Area.
        {
            this.researchArea = area;
            return this.researchArea;
        }
    }   
}    
