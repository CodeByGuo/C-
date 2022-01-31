using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Rock__Paper__Scissors_Game
{
    class Program
    {
        static void Game() //Funciton for the game
        {
            //Set all needed variables
            Random random = new Random();
            bool playAgain = true;
            string player; //Choice of the player
            string computer; //Generated choice from computer

            while (playAgain)
            {
                //Give string player and computer empty strings
                player = "";
                computer = "";


                //Nested Loop so players have to enter the right words in order for program to work
                while (player != "rock" && player != "paper" && player != "scissors")
                {
                    Console.WriteLine("Enter rock, paper, or scissors: ");
                    player = Console.ReadLine();
                    player = player.ToLower(); //Makes the choices all lowecase

                    Console.WriteLine($"You Chose: {player}");

                }

                //Create a generator for the Computer
                switch (random.Next(1, 4))
                {
                    //Rock
                    case 1:
                        computer = "rock";
                        break;

                    //Paper
                    case 2:
                        computer = "paper";
                        break;

                    //Scissor
                    case 3:
                        computer = "scissors";
                        break;
                }
                Console.WriteLine($"Computer Chose: {computer}");

                //Create an instance for determining who is going to win

                switch (player)
                {
                    case "rock":
                        if (computer == "rock")
                        {
                            Console.WriteLine("It is a draw!");
                        }
                        else if (computer == "paper")
                        {
                            Console.WriteLine("Sorry You Lose!");
                        }
                        else
                        {
                            Console.WriteLine("Yay! You Win!");
                        }
                        break;

                    case "paper":
                        if (computer == "rock")
                        {
                            Console.WriteLine("Yay! You Win!");
                        }
                        else if (computer == "paper")
                        {
                            Console.WriteLine("It is a Draw!");
                        }
                        else
                        {
                            Console.WriteLine("Sorry You Lose!");
                        }
                        break;


                    case "scissors":
                        if (computer == "rock")
                        {
                            Console.WriteLine("Sorry You Lose!");
                        }
                        else if (computer == "paper")
                        {
                            Console.WriteLine("Yay! You Win!");
                        }
                        else
                        {
                            Console.WriteLine("It is a Draw!");
                        }
                        break;



                }

                //After Game
                Console.WriteLine("What would you like to do?\n1. Play Again\n2. View Player Statistics\n3. View Leaderboard\n4. Quit\n\nEnter a number:");
                string again = Console.ReadLine();
                again = again.ToLower();

                if (again == "1")
                {
                    Game();
                }
                if (again == "2")
                {
                    //Still need to create functino to view stats
                }
                if (again == "3")
                {
                    Board();
                }
                if (again == "4")
                {
                    Console.WriteLine("Your game has been saved!");
                }


                else
                {
                    playAgain = false;
                }


            }
        }

        //Function to open and read file

        static void readFile(string NameOfPlayer)
        {
            string filename = "player_log.csv"; //filename
            using (StreamReader playerReader = new StreamReader(filename))
            {
                //Declare the amount of lines
                int lineNum = 1;

                var lines = playerReader.ReadLine();
                while (!playerReader.EndOfStream)
                {
                    lines = playerReader.ReadLine();
                    lineNum++;
                    var values = lines.Split(',');

                    string name = values[0];

                    if (name.Contains(NameOfPlayer))
                    {

                        Console.WriteLine($"Welcome Back {NameOfPlayer}! Lets play!");
                        Game();

                    }
                    else
                    {

                        Console.WriteLine($"Hello {NameOfPlayer} Let’s play!");
                        Game();
                    }
                }
            }
        }
        static void Board()
        {
            List<Player> playerList = new List<Player>(); //Create list (namespace has to be = to name of the class)

            try
            {
                using (var playerReader = new StreamReader("player_log.csv"))
                {
                    //Declare the amount of lines
                    int lineNum = 1;
                    int dataNum = 4;
                    var lines = playerReader.ReadLine();
                    while (!playerReader.EndOfStream)
                    {
                        lines = playerReader.ReadLine();
                        lineNum++;
                        var values = lines.Split(',');
                        if (values.Length != dataNum)
                        {
                            throw new Exception($"Row {lineNum} contains {values.Length} pieces of data. It should have {dataNum}");
                        }
                        try
                        {
                            string name = values[0];
                            int wins = Int32.Parse(values[1]);
                            int losses = Int32.Parse(values[2]);
                            int ties = Int32.Parse(values[3]);

                            Player player = new Player(name, wins, losses, ties);
                            playerList.Add(player);
                        }
                        catch (Exception e)
                        {
                            throw new Exception($"Row {lineNum} contains invalid data. ({e.Message})");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"There was an error reading the file {e.Message}");
            }

            var topTen = from players in playerList where players.Wins < 0 select players;
            Console.WriteLine("\n------------------\n\nTop 10 Winning Players\n");
            foreach (var Ten in topTen)
            {
                Console.WriteLine(Ten.ToString());

            }
            ///var mostPlayer = .OrderByDescending(music => music.Time).First();
        }



        static void Main(string[] args)
        {



            //Intro to the program
            Console.WriteLine("Welcome to Rock, Paper, Scissors!\n1. Start New Game\n2. Load Game\n3. Quit\n\nEnter choice: ");
            string choice = Console.ReadLine(); //Read choice




            //Choice 1
            if (choice == "1")
            {
                //Ask for name 
                Console.WriteLine(" What is your name?: ");
                string playerName = Console.ReadLine();
                readFile(playerName);

            }

            //Choice 2
            if (choice == "2")
            {
                //Ask for name 
                Console.WriteLine(" What is your name?: ");
                string playerName = Console.ReadLine();
                readFile(playerName);

            }

            if (choice == "3")
            {
                Console.WriteLine("Thank you for playing!!");
            }
        }
    }


}



