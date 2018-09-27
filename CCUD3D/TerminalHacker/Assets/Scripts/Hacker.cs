using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        var gretting = "Hello Ash";
        Terminal.WriteLine(gretting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the Local Library");
        Terminal.WriteLine("Press 2 for the Police Station");
        Terminal.WriteLine("Enter your selection:");
    }

    // Update is called once per frame
    void Update()
    {

    }
}