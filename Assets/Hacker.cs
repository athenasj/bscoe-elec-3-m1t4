using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {


    int level;

    enum Screen { Identify, MainMenu, Item, Win };

    Screen currentScreen = Screen.Identify; //I added a new screen for "login"

    string person;
    string[] weapon = { "arrow", "machete", "rifle", "sword", "pistol" };
    string[] building = { "brothel", "cottage", "hospital", "library", "stadium" };
    string[] automob = { "armored car", "ambulance", "convertible", "limousine", "motorcycle" };

    int randNum;
    int l1 = 0, l2 = 0, l3 = 0;

    // Use this for initialization
    void Start() {
        Terminal.WriteLine("M1T4 - San Jose & Taña");
        Terminal.WriteLine("You are on the verge of the apocalypse");
        Terminal.WriteLine("    ________");
        Terminal.WriteLine("   (  O   o )");
        Terminal.WriteLine("   /    0   \\   Zombies have");
        Terminal.WriteLine("  / /|    |\\ \\  overrun the world.");
        Terminal.WriteLine(" (\")  |  |  (\")");
        Terminal.WriteLine("      |  |      ");
        Terminal.WriteLine("      /  \\      ");
        Terminal.WriteLine("    _|    |_      ");
        Terminal.WriteLine("Identify yourself...");
    }

    // To show Main Menu
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("Figure out the words to attain a level of safety.");
        Terminal.WriteLine("\n" + "Press 1 for the weapons." + "\n" + "Press 2 for the building type." + "\n" + "Press 3 for the auto mobile." + "\n\n" + "Enter your selection:");

    }

    //when user enters something
    void OnUserInput(string input)
    {
        if (currentScreen == Screen.Identify)
        {
            IdentifyScreen(input);
        }
        else if (l1 == 1 && l2 == 1 && l3 == 1 && currentScreen != Screen.Win)
        {
            l1 = 0;
            l2 = 0;
            l3 = 0;
            FinishGame();
        }
        else if (input == "menu")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Hello, " + person + "!");
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Item)
        {
            CheckAnswer(input);
        }
        else if (currentScreen == Screen.Win)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Hello, " + person + "!");
            ShowMainMenu();
        }
    }

    private void FinishGame()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("    ________");
        Terminal.WriteLine("   (  O   o )");
        Terminal.WriteLine("   /    0   \\");
        Terminal.WriteLine("  / /|    |\\ \\ Congratulations!");
        Terminal.WriteLine(" (\")  |  |  (\") ");
        Terminal.WriteLine("      |  |      ");
        Terminal.WriteLine("      /  \\      ");
        Terminal.WriteLine("    _|    |_      ");
        Terminal.WriteLine("You survived the apocalypse!");
        Terminal.WriteLine("Press 'Enter' to reset all levels.");

    }

    void IdentifyScreen(string input)
    {
        if (input == "007")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Hello, Mr. Bond!");
            person = "Mr. Bond";
            ShowMainMenu();
        }
        if (input == "daryl" || input == "carol")
        {
            DarylCarolMethod();
            person = input;
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Hello, " + input + "!");
            person = input;
            ShowMainMenu();
        }
    }

    private void DarylCarolMethod()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("    ________");
        Terminal.WriteLine("   (  O   o )");
        Terminal.WriteLine("   /    0   \\");
        Terminal.WriteLine("  / /|    |\\ \\ INSTANT WIN!!!");
        Terminal.WriteLine(" (\")  |  |  (\") ");
        Terminal.WriteLine("      |  |      ");
        Terminal.WriteLine("      /  \\      ");
        Terminal.WriteLine("    _|    |_      ");
        Terminal.WriteLine("You survived the zombie apocalypse.");
        Terminal.WriteLine("Obviously...");
        Terminal.WriteLine("Press 'Enter' to actually play the game.");
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            Terminal.ClearScreen();
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            Terminal.ClearScreen();
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            Terminal.ClearScreen();
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose valid level!");
        }
    }

    void StartGame()
    {
        RandomNumber();
        currentScreen = Screen.Item;
        Terminal.WriteLine("Level "+ level);

        if (level == 1)
        {
            Terminal.WriteLine("Weapon");
            Terminal.WriteLine("PS: Answer all the levels to finish the game!");
            Terminal.WriteLine("Clue: " + StringExtension.Anagram(weapon[randNum]));
        }
        else if (level == 2)
        {
            Terminal.WriteLine("Building");
            Terminal.WriteLine("Clue: " + StringExtension.Anagram(building[randNum]));
        }
        else if (level == 3)
        {
            Terminal.WriteLine("Mobility");
            Terminal.WriteLine("Clue: " + StringExtension.Anagram(automob[randNum]));
        }


        Terminal.WriteLine("Guess:");
    }

    void CheckAnswer(string input)
    {
        if (input == weapon[randNum] && level == 1)
        {
            WeaponMethod();
        }
        else if (input == building[randNum] && level == 2)
        {
            BuildingMethod();
        }
        else if (input == automob[randNum] && level == 3)
        {
            AutomobMethod();
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Incorrect.");
            StartGame();
        }
    }

    private void AutomobMethod()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        l3 = 1;
        Terminal.WriteLine("    _____   ");
        Terminal.WriteLine("___/     \\___    Congratulations!");
        Terminal.WriteLine("|__( )  ( )___|");
        Terminal.WriteLine("\nYou now have mobility!");
    }

    private void BuildingMethod()
    {
        Terminal.ClearScreen();
        l2 = 1;
        Terminal.WriteLine("    ________");
        Terminal.WriteLine("   (  O   o )");
        Terminal.WriteLine("   /    0   \\   Congratulations!");
        Terminal.WriteLine("  /          \\");
        Terminal.WriteLine("  ~~~~~~~~~~~~~");
        Terminal.WriteLine("\nYou now have shelter!");
        currentScreen = Screen.Win;
    }

    private void WeaponMethod()
    {
        Terminal.ClearScreen();
        l1 = 1;
        currentScreen = Screen.Win;
        Terminal.WriteLine("  \\*  *  *//   ");
        Terminal.WriteLine("     / \\   ");
        Terminal.WriteLine("    |   |   ");
        Terminal.WriteLine("    | | |   ");
        Terminal.WriteLine(" ___| | |___   Well done!");
        Terminal.WriteLine(" | ~  O  ~ |  ");
        Terminal.WriteLine(" | _______ |");
        Terminal.WriteLine("    | + |   ");
        Terminal.WriteLine("     | |   ");
        Terminal.WriteLine("     |_|   ");
        Terminal.WriteLine("You now have a defense system!");
        
    }

    void RandomNumber()
    {   //possible additional code is .length
        randNum = UnityEngine.Random.Range(0,4);
    }

}
