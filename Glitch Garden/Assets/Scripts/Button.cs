using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;

    public static GameObject selectedDefender;

    private Button[] buttonArray;

    // Use this for initialization
    void Start()
    {
        // Find all items that have a "Button" script
        buttonArray = FindObjectsOfType<Button>();
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
