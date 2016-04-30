using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;
    private GameObject spawnerParent;
    private StarDisplay starDisplay;

    void Start()
    {
        spawnerParent = GameObject.Find("Defenders");

        if(!spawnerParent)
        {
            spawnerParent = new GameObject("Defenders");
        }

        starDisplay = FindObjectOfType<StarDisplay>();
    }

    void OnMouseDown()
    {
        GameObject defender = Button.selectedDefender;
        int defenderCost = defender.GetComponent<Defender>().starCost;
        
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            Vector2 rawpos = CalculateWorldPointOfMouseClick();
            Vector2 roundedPos = SnapToGrid(rawpos);
            GameObject newdef = Instantiate(defender, roundedPos, Quaternion.identity) as GameObject;
            newdef.transform.parent = spawnerParent.transform;
        }
        else
        {
            Debug.Log("Insufficient stars to spawn!");
        }
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 wierdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);

        return myCamera.ScreenToWorldPoint(wierdTriplet);
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
}
