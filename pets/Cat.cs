using System;
using System.Collections.Generic;

namespace pets
{
    public class Cat:Pet
    {
        public Cat(string name,string owner, double weight)
        : base("cat", name, owner, weight){}
        

        //Meow Function
        public string meow(int count)
        {
            int i = 2;
            string Meow = "meow.";
            while(i <= count)
            {
                Console.WriteLine(Meow);
                i++;
                
            }
            return Meow;
        }

    }
}