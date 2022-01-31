using System;
using System.Collections.Generic;

    namespace pets
    {
    public class Pet
    {
        //Instance Variables
        public string type;
        public string name;
        public string owner;
        public double weight;

        //Create a constructor
        public Pet(string type, string name, string owner, double weight)
        {
            this.type = type;
            this.name = name;
            this.owner = owner;
            this.weight = weight;
        }
       

        public string getTag()
        {
        return($"If lost, call {this.owner}");
        }
        public string getName()
        {
            return this.name;
        }
        public string getType()
        {
            return this.type;
        }
        public string getOwner()
        {
            return this.owner;
        }
        public double getWeight()
        {
            return this.weight;
        }
        public string newOwner(string name)
        {
            this.owner = name;
            return this.owner;
        }
        public double setWeight(double weight)
        {
            this.weight = weight;
            return this.weight;
        }
    }

    }