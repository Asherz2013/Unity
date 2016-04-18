using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    private Text starText;
    private int starCount = 100;

    public enum Status {SUCCESS, FAILURE};
    
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    public void AddStars(int amount)
    {
        starCount += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if (starCount >= amount)
        {
            starCount -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateDisplay()
    {
        starText.text = starCount.ToString();
    }
}
