using UnityEngine;

[DisallowMultipleComponent]
public class Oscellator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(5f, 0f, 0f);
    [SerializeField] float period = 2f;

    Vector3 startingPos;
    float movementFactor;
    const float tau = Mathf.PI * 2; // about 6.28

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Protect against "/ 0"
        if (period <= Mathf.Epsilon) return;

        float cycles = Time.time / period; // Grows continually from 0
        float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to 1
        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
