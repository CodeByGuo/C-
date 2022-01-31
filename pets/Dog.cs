using System;
using System.Collections.Generic;

namespace pets
{
    public class Dog:Pet //Inherit Properties from Pet
    {
        public Dog(string name, string owner, double weight) //constructor
        : base("dog", name, owner, weight){}

        //Create the bark function
        public string bark(int amount) 
        {
            int i = 2;
            string Woof = "bark!";
            while(i <= amount)
            {
                Console.WriteLine(Woof);
                i++;
                
            }
            return Woof;
        }
    }
}