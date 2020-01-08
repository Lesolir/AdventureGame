using System;

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
            Console.WriteLine("2. Load Game (saved games: {0}/10)", savedGames);
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
            int currentGame = savedGames + 1;
            hero[currentGame] = new Hero();

            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 9, Console.CursorTop);
            Console.WriteLine("Character Creation");
            Console.Write("\n\n\nPlease enter the name of your hero (confirm with ENTER):");
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
            int weaponUpgrade = hero[currentGame].GetWeaponUpgrade();
            int positionX = hero[currentGame].GetPositionX();
            int positionY = hero[currentGame].GetPositionY();

            Console.WriteLine("\nName: {0}\nLevel: {1}\nXP: {2}\nHealth: {3}\nAttack: {4}\nKeys: {5}\nPotion: {6}\nWeapon Upgrade: {7}\nPosition: X{8} || Y{9}",
                name, level, xp, health, attack, keys, potion, weaponUpgrade, positionX, positionY);
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
                Console.SetCursorPosition((Console.WindowWidth / 2) -6, Console.CursorTop + 1);
                Console.WriteLine("KeyQuest");
                HeroInfo(hero, ref currentGame);
                Console.WriteLine("What do you want to do?\n");
                Console.WriteLine("1. Go Up");
                Console.WriteLine("2. Go Right");
                Console.WriteLine("3. Go Down");
                Console.WriteLine("4. Go Left");
                Console.WriteLine("\n5. Watch the map");
                Console.WriteLine("6. Drink a potion");
                Console.WriteLine("7. Upgrade weapon");
                Console.WriteLine("\n8. Exit to main menu");
                Console.WriteLine("\nPlease select one of the above alternatives\nConfirm with ENTER");

                int heroX = hero[currentGame].GetPositionX()-1;
                int heroY = hero[currentGame].GetPositionY()-1;
                cell[heroX,heroY].SetVisited(1);
                int cellX = 0;
                int cellY = 0;
                Console.SetCursorPosition(Console.WindowLeft + 56, Console.CursorTop - 18);
                Console.WriteLine("Map of the vast and mysterious world");
                for(int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(Console.WindowLeft + 60, Console.CursorTop + 1);
                    for(int z = 60; z < 90; z+=3)
                    {
                        Console.SetCursorPosition(Console.WindowLeft + z, Console.CursorTop);
                        if(cell[cellX,cellY].GetVisited() == 0)
                            Console.Write("[ ]");
                        else if(cellX == heroX && cellY == heroY)
                            Console.Write("[@]");
                        else if(cell[cellX,cellY].GetVisited() == 1)
                            Console.Write("[x]");
                        cellX++;
                    }
                    cellX = 0;
                    cellY++;
                }

                //int.TryParse(Console.ReadLine(), out int answer);


                if (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 8)
                    ErrorInput();
                else
                    exit = true;
            }
            return answer;
        }
        static void WallError()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth) / 2 - 21, Console.CursorTop + 2);
            Console.WriteLine("You ran into a wall with your head first, be careful and don't hurt yourself...");
            Console.SetCursorPosition((Console.WindowWidth) / 2 - 11, Console.CursorTop + 1);
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();

        }
        // This is the error input message
        static void ErrorInput()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth) / 2 - 21, Console.CursorTop + 2);
            Console.WriteLine("ERROR! Invalid selection, please try again.");
            Console.SetCursorPosition((Console.WindowWidth) / 2 - 11, Console.CursorTop + 1);
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
                        //HeroInfo(hero, ref currentGame);
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
