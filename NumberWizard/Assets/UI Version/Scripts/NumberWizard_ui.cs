using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard_ui : MonoBehaviour
{
    int max;
    int min;
    int guess;

    int maxGuessesAllowed = 10;

    public Text text;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        max = 1000;
        min = 1;
        NextGuess();
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min,max+1);
        text.text = guess.ToString();
        maxGuessesAllowed--;
        if(maxGuessesAllowed<=0)
        {
            // Computer has reached it max number of guess so the player has won
            SceneManager.LoadScene("Win");
        }
    }
}
