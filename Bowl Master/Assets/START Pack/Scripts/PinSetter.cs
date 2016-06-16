using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour
{
    public int lastStandingCount = -1;
    public Text standingDisplay;
    public GameObject pinSet;

    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;
    
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        standingDisplay.text = CountStanding().ToString();
        if (ballEnteredBox)
        {
            UpdateStandingCountAndSettle();
        }
    }

    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseifStanding();
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position += new Vector3(0, 20, 0);
    }

    void UpdateStandingCountAndSettle()
    {
        int currentStanding = CountStanding();

        if(currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        if((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        ball.Reset();
        lastStandingCount = -1;
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }

    int CountStanding()
    {
        int standing = 0;

        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if(pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<Pin>())
        {
            Destroy(collider.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }
}
