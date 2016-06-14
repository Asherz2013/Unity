using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour
{
    public Text standingDisplay;
    public int lastStandingCount = -1;

    private Ball ball;
    private bool ballEnteredBox = false;
    private float lastChangeTime;
    
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        standingDisplay.text = CountStanding().ToString();
        if (ballEnteredBox)
        {
            CheckStanding();
        }
    }

    void CheckStanding()
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
        standingDisplay.color = Color.green;
        lastStandingCount = -1;
        ballEnteredBox = false;

        ball.Reset();
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

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.GetComponent<Pin>())
        {
            Destroy(collider);
        }
    }
}
