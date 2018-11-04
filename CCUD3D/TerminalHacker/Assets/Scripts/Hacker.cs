using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game Configuration data
    string menuHint = "You may type 'menu' at any time.");
    //string[,] levelPasswords = { { "books", "aisle", "self", "password", "font", "borrow" }, { "prisoner", "handcuffs", "holster", "uniform", "arrest" } };
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };

    // Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    string password;

    // Use this for initialization
    void Start()
    {
        print(level1Passwords.Length);
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
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr. Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
            Terminal.WriteLine(menuHint);
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;

            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;

            default:
                Debug.LogError("Invalid Level Number! " + level);
                break;
        }
    }

    void RunPasswordCracker(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Sorry Wrong Password!");
            StartGame();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      // 
 /______//                
(______(/
                ");
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '
                ");
                break;
            default:
                Debug.LogError("Invalid Level Reached! " + level);
                break;
        }
        
    }
}