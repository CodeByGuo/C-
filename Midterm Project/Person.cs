using System;
using System.Collections.Generic;

namespace Midterm_Project
{

    public enum Category{student, faculty, staff}; //Create categories of the people
    
    public class Person
    {
        //Instance variables
        private string firstName;
        private string lastName;
        private string id;
        private Category category;
        


        public Person(string firstName,string lastName, string id, Category category) //constructor
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.category = category;
        }
        public void getPersonInfo() //prints name | id | type
        {
            Console.WriteLine("Name: " + (firstName) + " " + (lastName));
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Type: {category.ToString()}");
        }
        public string getFirstName()  //returns first name
        {
            return this.firstName;
        }

        public void setFirstName(string newName) //change first name
        {
            this.firstName = newName;
        }

        public string getlastName() //gets last name
        {
            return this.lastName;
        }

        public void setLastName(string newLast) //sets new last name
        {
            this.lastName = newLast;
        }
        public Category getCategory()
        {
            return category;
        }

        public Category setCategory(Category type) //sets the category of the person
        {
            this.category = type;
            return this.category;
        }
        public string getID() //returns id
        {
            return this.id;
        }
        
    }
}
