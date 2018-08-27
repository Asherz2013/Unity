using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public float levelSeconds = 100;

    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;

    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();

        winLabel = GameObject.Find("You Win");
        if (winLabel) winLabel.SetActive(false);
        else Debug.LogWarning("Can not find 'You Win' object");
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        if(Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            DestroyAllTaggedObjects();
            isEndOfLevel = true;
            winLabel.SetActive(true);
            audioSource.Play();
            Invoke("LoadNextLevel", audioSource.clip.length);
        }
    }

    // Destroys all obejects with tag: destroyOnWin
    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");

        foreach(GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
