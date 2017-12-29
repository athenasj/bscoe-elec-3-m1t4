using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {


    int level;

    enum Screen { Identify, MainMenu, Password, Win};

    Screen currentScreen = Screen.Identify; //I added a new screen for "login"

    string person;
    string [] weapon = { "arrow", "machete", "rifle", "sword", "pistol" };
    string [] building = { "brothel", "cottage", "hospital", "library", "stadium" };
    string[] automob = { "armored car","ambulance","convertible","limousine","motorcycle"};

    int randNum;


    // Use this for initialization
    void Start () {
        Terminal.WriteLine("You are on the verge of the apocalypse.");
        Terminal.WriteLine("Zombies have overrun the world.");
        Terminal.WriteLine("Identify yourself...");
    }

    // To show Main Menu
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("SW2T4");
        Terminal.WriteLine("Figure out the words to attain a level of safety.");
        Terminal.WriteLine("\n" + "Press 1 for the weapons." + "\n" + "Press 2 for the building type." + "\n" + "Press 3 for the auto mobile." + "\n\n" + "Enter your selection:");

    }

    void OnUserInput(string input)
    {
        if (currentScreen == Screen.Identify)
        {
            IdentifyScreen(input);
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
        else if (currentScreen == Screen.Password)
        {
            CheckAnswer(input);
        }
        else if (currentScreen == Screen.Win)
        {
            Terminal.WriteLine("Hello, " + person + "!");
            ShowMainMenu();
        }
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
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Hello, " + input + "!");
            person =input;
            ShowMainMenu();
        }
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
        currentScreen = Screen.Password;
        Terminal.WriteLine("Level "+ level);
        if (level == 1)
        {
            Terminal.WriteLine("Weapon");
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
            Terminal.ClearScreen();
            Terminal.WriteLine("You now have a defense system!");
            currentScreen = Screen.Win;
        }
        else if (input == building[randNum] && level == 2)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You now have shelter!");
            currentScreen = Screen.Win;
        }
        else if (input == automob[randNum] && level == 3)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You now have a mobility!");
            currentScreen = Screen.Win;
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Incorrect.");
            StartGame();
        }
    }

    void RandomNumber()
    {   //possible additional code is .length
        randNum = UnityEngine.Random.Range(0,4);
    }

}
