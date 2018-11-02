using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the Local Library");
        Terminal.WriteLine("Press 2 for the Police Station");
        Terminal.WriteLine("Enter your selection:");
    }

    // Message - Holds the users input
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else
        {
            switch (currentScreen)
            {
                case Screen.MainMenu:
                    RunMainMenu(input);
                    break;

                case Screen.Password:
                    RunPasswordCracker(input);
                    break;

                case Screen.Win:
                    break;
            }
        }
    }

    void RunMainMenu(string input)
    {
        // Print will evaluate to a boolean based on expression
        //print(input == "1");
        if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr. Bond!");
        }
        else if (input == "1")
        {
            level = 1;
            password = "donkey";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "password";
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have choosen " + level);
        Terminal.WriteLine("Please enter your password: ");
    }

    void RunPasswordCracker(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Congratulations this is correct.");
        }
        else
        {
            Terminal.WriteLine("Sorry Wrong Password!");
        }
    }
}