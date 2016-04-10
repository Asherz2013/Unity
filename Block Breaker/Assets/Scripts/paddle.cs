using UnityEngine;

public class paddle : MonoBehaviour
{
    public bool autoplayer = false;

    private Ball ball;

    // Start method
    void Start()
    {
        // Find the ball in the level
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoplayer) MovewithMouse();
        else AutoPlay();
    }

    void MovewithMouse()
    {
        float mousePosInBlocks;
        // Game space is 16 units wide.
        // Mouse pos / screen gives a relative value
        // relative * 16 gives how many blocks we are at.
        mousePosInBlocks = (Input.mousePosition.x / Screen.width) * 16;
        // Move the paddle to the position of the mouse. keeping Y the same as on screen
        transform.position = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), transform.position.y, 0f);
    }

    void AutoPlay()
    {
        // Obtain the position of the ball
        Vector3 ballpos = ball.transform.position;
        // Move the paddle to the position of the balls X. keeping Y the same as on screen
        transform.position = new Vector3(Mathf.Clamp(ballpos.x, 0.5f, 15.5f), transform.position.y, 0f);
    }
}
