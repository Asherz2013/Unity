using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private paddle m_paddle;

    private Vector3 m_paddleToBallVector;
    private bool m_hasStarted = false;

	// Use this for initialization
	void Start ()
    {
        m_paddle = FindObjectOfType<paddle>();
        // Find the distance between the ball and the paddle
        m_paddleToBallVector = transform.position - m_paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If the game hasn't started
        if (!m_hasStarted)
        {
            // Lock the ball to the paddle
            transform.position = m_paddle.transform.position + m_paddleToBallVector;

            // Once the player has clicked the mouse button we launch the ball
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                m_hasStarted = true;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ball does not trigger sound when brick is destroyed
        // not 100% sure why, possibly because brick isn't there
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (m_hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
