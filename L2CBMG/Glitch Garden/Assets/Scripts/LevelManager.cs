using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float AutoLoadNextLevelAfter;

    void Start()
    {
        if(AutoLoadNextLevelAfter <= 0.0f)
        {
            Debug.Log("Level auto load less than 0 seconds. Please enter a value bigger than 0.");
        }
        else
        {
            Invoke("LoadNextLevel", AutoLoadNextLevelAfter);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

}
