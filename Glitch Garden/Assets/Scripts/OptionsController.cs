using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider diffSlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

    // Use this for initialization
    void Start()
    {
        // Find the Music manager
        musicManager = FindObjectOfType<MusicManager>();
        // Set the Volume Slider to the value stated in the player prefs
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        // Set the Difficulties Slider to the value stated in the player prefs
        diffSlider.value = PlayerPrefsManager.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        // Change the volume on the fly.
        musicManager.SetVolume(volumeSlider.value);
    }

    // Save all values and return to the start screen
    public void SaveAndExit()
    {
        // Store the value of the Volume to the player prefs
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        // Store the difficulty value to the player prefs
        PlayerPrefsManager.SetDifficulty(diffSlider.value);
        // Return back to the "Start" menu
        levelManager.LoadLevel("01a Start");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        diffSlider.value = 2f;
    }
}
