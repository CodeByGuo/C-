using System;
namespace Dog
{
     public enum Gender { Male,Female};
    class Dog
    {
        //Instance variables
        public string name;
        public string owner;
        public int age;
        public Gender gender;
        //Constructor
        public Dog(string name,string owner,int age,Gender gender)
        {
            this.name = name;
            this.owner = owner;
            this.age = age;
            this.gender = gender;
        }

        public string Bark(int amount) //Bark Method
        {
            int i = 0;
            string Woof = "Woof!";
            while(i < amount)
            {
                Console.WriteLine(Woof);
                i++;
                
            }
            return Woof;
            
        }
        public string GetTag()
        {
            string tag = $"If lost, call {this.owner}. ";
            if (gender == 0)
            {
                tag += $"His name is {this.name} he is {this.age}";
            }
            else
            {
                tag += $"Her name is {this.name} she is {this.age}";
            }
            if (age > 1)
            {
                tag += " years old.";
            }
            else
            {
                tag += " year old.";
            }
            return tag;
        }
    }
    }





















