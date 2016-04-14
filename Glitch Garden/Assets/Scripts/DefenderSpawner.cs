using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;

    private GameObject Parent;

    void Start()
    {
        Parent = GameObject.Find("Defenders");

        if(!Parent)
        {
            Parent = new GameObject("Defenders");
        }
    }

    void OnMouseDown()
    {
        Vector2 rawpos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawpos);

        GameObject defender = Instantiate(Button.selectedDefender, roundedPos, Quaternion.identity) as GameObject;
        defender.transform.parent = Parent.transform;
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
