using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    // Loads a new Scene by name
    public void LoadLevel(string name)
    {
        Brick.m_breakableCount = 0;
        SceneManager.LoadScene(name);
    }

    // Loads the next Scene in the build list.
    public void LoadNextLevel()
    {
        Brick.m_breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Closes the Application
    // This does NOT work on Web Apps
    public void QuitRequest()
    {
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        // if last brick was destroyed then we load the next level
        if(Brick.m_breakableCount<=0) LoadNextLevel();
    }
}
