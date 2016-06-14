using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Ball m_ball;

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

    // Use this for initialization
    void Start()
    {
        m_ball = GetComponent<Ball>();
    }

    public void DragStart()
    {
        if (!m_ball.inPlay)
        {
            // Capture time and position of drag start (mouse click)
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd()
    {
        if (!m_ball.inPlay)
        {
            // launch the ball
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;

            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

            Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
            m_ball.Launch(launchVelocity);
        }
    }

    public void MoveStart (float amount)
    {
        if (!m_ball.inPlay)
        {
            m_ball.transform.Translate(new Vector3(amount, 0, 0));
        }
    }
}
