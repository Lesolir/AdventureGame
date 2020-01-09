﻿using System;

namespace KeyQuest
{
    class Program
    {
        // This states the version of the program
        static void BuildVersion()
        {
            Console.SetCursorPosition(Console.WindowWidth - 8, Console.WindowHeight - 2);
            Console.WriteLine("V. 0.01");
        }
        //This is the main menu of the program
        static int MainMenu()
        {
            string saved = "0";
            try
            {
                saved = System.IO.File.ReadAllText(@"SavedGames.txt");
            }
            catch
            {
                System.IO.File.WriteAllText(@"SavedGames.txt", saved);
            }
            int savedGames = int.Parse(saved);
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 7, Console.CursorTop + 6);
            Console.WriteLine("Main Menu");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 16, Console.CursorTop + 2);
            Console.WriteLine("1. New Game (free slots: {0}/10)", 10 - savedGames);
            Console.SetCursorPosition((Console.WindowWidth / 2) - 16, Console.CursorTop);
            Console.WriteLine("2. Load Game Menu (saved games: {0}/10)", savedGames);
            Console.SetCursorPosition((Console.WindowWidth / 2) - 16, Console.CursorTop);
            Console.WriteLine("3. Exit");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 25, Console.CursorTop + 2);
            Console.WriteLine("Please select an option and confirm with ENTER");
            return savedGames;
        }
        // This is the Create new game menu
        static int NewGame(Hero[] hero)
        {
            //Hero[] hero = new Hero[10];
            string saved = System.IO.File.ReadAllText(@"SavedGames.txt");
            int savedGames = int.Parse(saved);
            int currentGame = savedGames;
            hero[currentGame] = new Hero();

            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 9, Console.CursorTop);
            Console.WriteLine("Character Creation");
            Console.Write("\n\n\nPlease enter the name of your hero (confirm with ENTER): ");
            string answer = Console.ReadLine();
            hero[currentGame].SetName(answer);
            Console.Clear();
            Console.WriteLine("\n\nWelcome {0}! You seem to be confused why you are here in this empty space.", answer);
            Console.WriteLine("The truth is, you are dead...but I'm willing to give you another chance to live that is if you can clear my quest for you.");
            Console.WriteLine("Behind me there is a portal and it will lead you to a dungeon of some sort with a lot of secrets, there is 10 rooms filled with monsters, if you are lucky there will be none.");
            Console.WriteLine("You have to find 10 keys after that you need to reach the last room and enter the portal to go back to your normal life and your memory of me and this place will be erased.");
            Console.WriteLine("I wish you luck..hehe..");
            Console.WriteLine("{0}: ..what was that creature..? *slowly enters the portal*", answer);

            HeroInfo(hero, ref currentGame);
            Console.WriteLine("\n\nStart Game: Press ENTER");
            Console.ReadLine();



            savedGames++;
            saved = savedGames.ToString();
            System.IO.File.WriteAllText(@"SavedGames.txt", saved);
            return currentGame;
        }
        // This displays hero info to the console
        static void HeroInfo(Hero[] hero, ref int currentGame)
        {
            //string saved = System.IO.File.ReadAllText(@"SavedGames.txt");
            //int savedGames = int.Parse(saved);
            string name = hero[currentGame].GetName();
            int level = hero[currentGame].GetLevel();
            int xp = hero[currentGame].GetXP();
            int health = hero[currentGame].GetHealth();
            int attack = hero[currentGame].GetAttack();
            int keys = hero[currentGame].GetKeys();
            int potion = hero[currentGame].GetPotion();
            int positionX = hero[currentGame].GetPositionX();
            int positionY = hero[currentGame].GetPositionY();

            Console.WriteLine("\nName: {0}\nLevel: {1}\nXP: {2}\nHealth: {3}\nAttack: {4}\nKeys: {5}\nPotion: ",
                name, level, xp, health, attack, keys, potion);
        }
        // This builds the world
        static void BuildNewWorld(Cell[,] cell)
        {
            //Cell[,] cell = new Cell[10,10];

            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 7, Console.CursorTop + 10);
            Console.WriteLine("Building World");

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    cell[x, y] = new Cell();
                    cell[x, y].SetLandType();
                    System.Threading.Thread.Sleep(10);
                    Console.Write(".");
                }

            }

            PlaceMobs(cell);
            PlaceKeys(cell);

        }
        // This places mobs in 10 cells
        static void PlaceMobs(Cell[,] cell)
        {
            Random random = new Random();
            int x = 0, y = 0, mob = 0;
            for (int i = 0; i < 10; i++)
            {
                x = random.Next(0, 10);
                y = random.Next(0, 10);
                mob = cell[x, y].GetMobs();
                if (mob == 0)
                    if (cell[x, y] == cell[0, 9] || cell[x, y] == cell[9, 0])
                        i--;
                    else
                        cell[x, y].SetMob();
                else
                    i--;
            }
        }
        // This places keys in 10 cells
        static void PlaceKeys(Cell[,] cell)
        {
            Random random = new Random();
            int x = 0, y = 0, key = 0;
            for (int i = 0; i < 10; i++)
            {
                x = random.Next(0, 10);
                y = random.Next(0, 10);
                key = cell[x, y].GetKey();
                if (key == 0)
                    if (cell[x, y] == cell[0, 9] || cell[x, y] == cell[9, 0])
                        i--;
                    else
                        cell[x, y].SetKey(1);
                else
                    i--;
            }
        }
        // This is the load game menu
        static string LoadGameMenu()
        {
            string saved = System.IO.File.ReadAllText(@"SavedGames.txt");
            int savedGames = int.Parse(saved);
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, Console.CursorTop + 6);
            Console.WriteLine("Load Game Menu");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.CursorTop + 2);
            Console.WriteLine("Saved games: {0}/10)", savedGames);
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, Console.CursorTop);
            Console.WriteLine("1. Load Game");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, Console.CursorTop);
            Console.WriteLine("2. Delete Game");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, Console.CursorTop);
            Console.WriteLine("3. Exit");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 25, Console.CursorTop + 2);
            Console.WriteLine("Please select an option and confirm with ENTER");
            Console.SetCursorPosition((Console.WindowWidth) / 2 - 7, Console.CursorTop + 2);
            string choice = Console.ReadLine();
            return choice;
        }
        // This is the load game
        static int LoadGame()
        {
            int currentGame = 0;
            return currentGame;
        }
        // This is the delete game menu
        static void DeleteGame()
        {
            string saved = System.IO.File.ReadAllText(@"SavedGames.txt");
            int savedGames = int.Parse(saved);
            if(savedGames > 0)
                savedGames--;
            saved = savedGames.ToString();
            System.IO.File.WriteAllText(@"SavedGames.txt", saved);
        }
        // This loads a saved world
        static void LoadWorld(Cell[,] cell)
        {

        }
        // This is the action menu
        static int HeroAction(Hero[] hero, ref int currentGame, ref Cell[,] cell)
        {
            int answer = 0;
            bool exit = false;
            while (exit == false)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowLeft + 56, Console.CursorTop + 1);
                Console.WriteLine("KeyQuest");
                HeroInfo(hero, ref currentGame);
                Console.WriteLine("\n-----------------------");
                Console.WriteLine("\nWhat do you want to do?\n");
                Console.WriteLine("1. Go Up");
                Console.WriteLine("2. Go Right");
                Console.WriteLine("3. Go Down");
                Console.WriteLine("4. Go Left");
                Console.WriteLine("\n5. Drink a potion");
                Console.WriteLine("6. Upgrade weapon");
                Console.WriteLine("\n7. Exit to main menu");
                Console.WriteLine("\nPlease select one of the above alternatives\nConfirm with ENTER");

                int heroX = hero[currentGame].GetPositionX() - 1;
                int heroY = hero[currentGame].GetPositionY() - 1;
                cell[heroX, heroY].SetVisited(1);
                int cellX = 0;
                int cellY = 0;
                Console.SetCursorPosition(Console.WindowLeft + 56, Console.CursorTop - 18);
                Console.WriteLine("Map of the vast and mysterious world");
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(Console.WindowLeft + 60, Console.CursorTop + 1);
                    for (int z = 60; z < 90; z += 3)
                    {
                        Console.SetCursorPosition(Console.WindowLeft + z, Console.CursorTop);
                        if (cell[cellX, cellY].GetVisited() == 0)
                            Console.Write("[ ]");
                        else if (cellX == heroX && cellY == heroY)
                            Console.Write("[@]");
                        else if (cell[cellX, cellY].GetVisited() == 1)
                            Console.Write("[x]");
                        cellX++;
                    }
                    cellX = 0;
                    cellY++;
                }
                
                Console.SetCursorPosition(Console.WindowLeft + 21, Console.CursorTop + 6);
                if (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 8)
                    ErrorInput();
                else
                    exit = true;
            }
            return answer;
        }
        // This is the view when player enters a new landscape
        static int Landscape(Cell[,] cell, ref Hero[] hero, ref int currentGame, ref int heroX, ref int heroY)
        {
            string land = cell[heroX,heroY].GetLandType();
            int clearGame = 0;
            Console.Clear();
            if (cell[heroX,heroY] == cell[0, 9])
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 6);
                Console.WriteLine("You are at the entrance to the mysterious world");
            }
            else if (cell[heroX, heroY] == cell[9, 0])
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 6);
                Console.WriteLine("You come to a great door. You can feel the smell of home..");
                if(hero[currentGame].GetKeys() == 10)
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                        Console.WriteLine("You slowly unlock the door.");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 1);
                        Console.WriteLine("Slowly the door creeks open..");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 4);
                        Console.WriteLine("You are the best! You can feel the life flowing back to you..You cleared the quest!");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                        Console.WriteLine("Press ENTER");
                        Console.ReadLine();
                        clearGame = 1;
                    }   
            }
            else
            {   Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 6);
                Console.WriteLine("You come to {0}", land);
                Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                Console.WriteLine("Scanning for hostile creatures");
                Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 1);
                for(int i = 0; i < 20; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            return clearGame;
        }
        // This is when player encounters a monster
        static string Encounter(Cell[,] cell, ref Hero[]hero, ref int currentGame, ref int heroX, ref int heroY)
        {
            bool exit = false;
            string choice = "";
            while(!exit)
            {
                int mobs = cell[heroX,heroY].GetMobs();
                Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 1);
                Console.WriteLine("You are surprised by");
                for(int i = 0; i < mobs; i++)
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 1);
                    Console.WriteLine(cell[heroX,heroY].GetMobName(i));
                }

                Console.SetCursorPosition((Console.WindowWidth / 2), Console.CursorTop + -6);
                Console.WriteLine("PREPARE!");
                Console.SetCursorPosition((Console.WindowWidth / 2), Console.CursorTop + 1);
                Console.WriteLine("What do you do?");
                Console.SetCursorPosition((Console.WindowWidth / 2), Console.CursorTop + 1);
                Console.WriteLine("1. Charge and fight like a man!");
                Console.SetCursorPosition((Console.WindowWidth / 2), Console.CursorTop + 1);
                Console.WriteLine("2. Poop your pants a litte...then fight!");
                Console.SetCursorPosition((Console.WindowWidth / 2), Console.CursorTop + 1);
                Console.WriteLine("3. Turn and run as fast as you can!");

                Console.SetCursorPosition((Console.WindowWidth / 2) - 11, Console.CursorTop + 1);
                Console.Write("Hurry and choose one af the actions above! Confirm with ENTER ");
                choice = Console.ReadLine();
                if(choice == "1" || choice == "2" || choice == "3")
                    exit = true;
                else
                {
                    ErrorInput();
                    Console.Clear();
                    Landscape(cell, ref hero, ref currentGame, ref heroX, ref heroY);
                }
            }
            return choice;
        }
        // This is where the monsterfight happens
        static int MonsterFight(Cell[,] cell, Hero[] hero, ref int currentGame, ref int heroX, ref int heroY)
        {
            Random random = new Random();
            int mobDmg, health, alive = 1;
            Console.Clear();
            for(int i = 0; i < cell[heroX,heroY].GetMobs(); i++)
            {
                cell[heroX,heroY].SetMobHealth(0, ref i);
                mobDmg = random.Next(1, 6);
                if(mobDmg == 3)
                {
                    health = hero[currentGame].GetHealth();
                    health -= 10;
                    hero[currentGame].SetHealth(health);
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                    Console.WriteLine("You took 10 damage from {0}", cell[heroX,heroY].GetMobName(i));
                    if(health == 0)
                        alive = 0;
                }
                if(alive == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 6);
                    Console.WriteLine("You died...again...");
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                    Console.WriteLine("So...what now?");
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                    Console.WriteLine("Press ENTER to get the chance to embark on a new adventure");
                    Console.ReadLine();
                    break;
                }
                Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                Console.WriteLine("You killed {0}", cell[heroX,heroY].GetMobName(i));
                Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
            }
            cell[heroX, heroY].SetMobs();
            return alive;
        }
        // This looks for a key in the cell
        static void FindKey(Cell[,] cell, Hero[] hero, ref int currentGame, ref int heroX, ref int heroY)
        {
            Console.Clear();
            if(cell[heroX,heroY].GetKey() == 1)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                System.Console.WriteLine("You found a key!!");
                hero[currentGame].SetKeys(1);
                Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                System.Console.WriteLine("Press ENTER to continue your adventure");
                Console.ReadLine();
            }
        }
        // This is when player try to go out of bounds
        static void WallError()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
            Console.WriteLine("You ran into a wall with your head first, be careful and don't hurt yourself...");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 11, Console.CursorTop + 1);
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }
        // This is the error input message
        static void ErrorInput()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 21, Console.CursorTop + 2);
            Console.WriteLine("ERROR! Invalid selection, please try again.");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 11, Console.CursorTop + 1);
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }
        // ============================================================================================
        // ============================================================================================
        // MAIN
        static void Main(string[] args)
        {
            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop + 6);
            Console.WriteLine("KeyQuest");
            Console.SetCursorPosition((Console.WindowWidth - 23) / 2, Console.CursorTop + 4);
            Console.WriteLine("Press ENTER to continue");
            BuildVersion();
            Console.ReadLine();

            Console.Clear();
            Console.Write("\n\n\n\n\n\n\t\tLoading awesome adventures.");
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(200);
                Console.Write(".");
            }

            string choice = "0";
            int alive = 1, clearGame = 0;
            Hero[] hero = new Hero[10];
            Cell[,] cell = new Cell[10, 10];
            bool exit = false;
            while (!exit)
            {
                int savedGames = MainMenu();
                BuildVersion();
                bool runGame = false, newGame = false, loadGame = false;
                int currentGame = 0;

                Console.SetCursorPosition((Console.WindowWidth) / 2 - 7, Console.CursorTop - 12);
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (savedGames < 10)
                    {
                        currentGame = NewGame(hero);
                        runGame = true;
                        newGame = true;
                    }
                    else
                    {
                        ErrorInput();
                        Console.WriteLine("\n\nThere are no free slots for new games");
                        Console.WriteLine("Please delete a saved game to be able to create a new game");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                    }
                }
                else if (choice == "2")
                {
                    if (savedGames > 0)
                    {
                        while(exit == false)
                        {
                            choice = LoadGameMenu();
                            currentGame = LoadGame();
                            if(choice == "1")
                            {
                                runGame = true;
                                loadGame = true;
                            }
                            else if(choice == "2")
                                DeleteGame();
                            else if(choice == "3")
                                exit = true;
                        }
                        exit = false;
                    }
                    else
                    {
                        ErrorInput();
                        Console.WriteLine("\n\nThere are no saved games");
                        Console.WriteLine("Please create a new game to play");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                    }
                }
                else if (choice == "3")
                {
                    exit = true;
                }
                else
                {
                    ErrorInput();
                }

                if (runGame)
                {
                    if (newGame)
                        BuildNewWorld(cell);
                    else if (loadGame)
                        LoadWorld(cell);

                    int answer = 0;
                    while (!exit)
                    {
                        Console.Clear();
                        answer = HeroAction(hero, ref currentGame, ref cell);
                        int test = 0;

                        switch (answer)
                        {
                            case 1:
                                test = hero[currentGame].GetPositionY();
                                if (test == 1)
                                    WallError();
                                else
                                    hero[currentGame].SetPositionY(-1);
                                break;
                            case 2:
                                test = hero[currentGame].GetPositionX();
                                if (test == 10)
                                    WallError();
                                else
                                    hero[currentGame].SetPositionX(+1);
                                break;
                            case 3:
                                test = hero[currentGame].GetPositionY();
                                if (test == 10)
                                    WallError();
                                else
                                    hero[currentGame].SetPositionY(+1);
                                break;
                            case 4:
                                test = hero[currentGame].GetPositionX();
                                if (test == 1)
                                    WallError();
                                else
                                    hero[currentGame].SetPositionX(-1);
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                exit = true;
                                break;
                            default:
                                break;
                        }
                        if(answer > 0 && answer < 5)
                        {
                            int heroX = hero[currentGame].GetPositionX() - 1;
                            int heroY = hero[currentGame].GetPositionY() - 1;
                            clearGame = Landscape(cell, ref hero, ref currentGame, ref heroX, ref heroY);
                            if(cell[heroX,heroY].GetMobs() > 0)
                            {
                                choice = Encounter(cell, ref hero, ref currentGame, ref heroX, ref heroY);
                                if(choice == "1" || choice == "2")
                                    alive = MonsterFight(cell, hero, ref currentGame, ref heroX, ref heroY);
                                else
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition((Console.WindowWidth / 2) - 36, Console.CursorTop + 6);
                                    Console.WriteLine("You turn around and run for your life. You can hear the evil snarls and shouts behind you..");
                                    Console.SetCursorPosition((Console.WindowWidth / 2) - 36, Console.CursorTop + 2);
                                    System.Console.WriteLine("Press ENTER to continue your adventure");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                if(cell[heroX, heroY] != cell[0, 9] || cell[heroX, heroY] == cell[9, 0])
                                {
                                    Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                                    Console.WriteLine("Your exceptional senses can not find anything hiding");
                                    Console.SetCursorPosition((Console.WindowWidth / 2) - 34, Console.CursorTop + 2);
                                    System.Console.WriteLine("Press ENTER to continue your adventure");
                                    Console.ReadLine();
                                }
                            }
                            FindKey(cell, hero, ref currentGame, ref heroX, ref heroY);
                        }
                        if(alive == 0 || clearGame == 1)
                            exit = true;
                    }
                    exit = false;
                }
            }

            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - 21) / 2, Console.CursorTop + 6);
            Console.WriteLine("Thank you for playing!");
            Console.SetCursorPosition((Console.WindowWidth - 19) / 2, Console.CursorTop + 4);
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 30, Console.CursorTop + 10);
            Console.Write("Chasing away the last monsters.");
            for (int i = 0; i < 15; i++)
            {
                System.Threading.Thread.Sleep(200);
                Console.Write(".");
                if (i == 4)
                    Console.Write("Shoo shoo.");
            }
        }
    }
}