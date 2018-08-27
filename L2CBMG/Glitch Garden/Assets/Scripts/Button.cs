using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;

    public static GameObject selectedDefender;

    private Button[] buttonArray;
    private Text costText;

    // Use this for initialization
    void Start()
    {
        // Find all items that have a "Button" script
        buttonArray = FindObjectsOfType<Button>();

        // Obtain the cost text which is a child of the button
        costText = GetComponentInChildren<Text>();
        // If we CAN'T find it then we should error
        if(!costText) Debug.LogWarning(name + " has no cost text.");
        // Find the prefab associated with this button. Find its "Defender" script and then the "Star Cost".
        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
    }
    
    void OnMouseDown()
    {
        // Loop through each button and make it Black
        foreach(Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        // change the colour of this sprite to White.
        GetComponent<SpriteRenderer>().color = Color.white;
        // Make the Static Var the prefab we want to place down
        selectedDefender = defenderPrefab;
    }
}
