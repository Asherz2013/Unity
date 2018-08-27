using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float FadeInTime;

    private Image m_fadePanel;
    private Color m_currentColour = Color.black;

    // Use this for initialization
    void Start()
    {
        // Obtain the Image Component
        m_fadePanel = GetComponent<Image>();
        // Change its Alpha to Transparent
        m_currentColour.a = 255;
        // Set its colour to Black
        m_fadePanel.color = m_currentColour;
    }

    // Update is called once per frame
    void Update()
    {
        // If the time since we loaded is less than the specified Fade in time
        if (Time.timeSinceLevelLoad < FadeInTime)
        {
            // Fade In
            float AlphaChange = Time.deltaTime / FadeInTime;
            m_currentColour.a -= AlphaChange;
            m_fadePanel.color = m_currentColour;
        }
        // Else deactivate the gameobject
        else gameObject.SetActive(false);
    }
}
