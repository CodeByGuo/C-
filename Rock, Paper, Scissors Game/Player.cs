using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock__Paper__Scissors_Game
{
    public class Player
    {
        private string _name;
        private int _wins;
        private int _losses;
        private int _ties;

        public Player(string name, int wins, int losses, int ties)
        {
            Name = name;
            Wins = wins;
            Losses = losses;
            Ties = ties;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Wins
        {
            get { return _wins; }
            set { _wins = value; }
        }

        public int Losses
        {
            get { return _losses; }
            set { _losses = value; }
        }
        public int Ties
        {
            get { return _ties; }
            set { _ties = value; }
        }



    }

}