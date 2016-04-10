using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float Speed = 15.0f;
    public float Padding = 1f;
    public GameObject Laser;
    public float laserSpeed = 0;
    public float firingRate = 0.2f;

    public AudioClip FireSound;

    public float Health = 250f;

    float xMin;
    float xMax;

    void Start()
    {
        // Distance from the player to the camera
        float distance = transform.position.z - Camera.main.transform.position.z;
        // Find the left side of the game screen
        Vector3 Leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        // Find the right side of the game screen
        Vector3 Rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        // Apply the X to the Min and Max for Clamping
        xMin = Leftmost.x + Padding;
        xMax = Rightmost.x - Padding;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Move Ship left
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // Move ship right
            transform.position += Vector3.right * Speed * Time.deltaTime;
        }
        // Clamp the X to be within the screen
        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        // re apply to clamped x to the transform
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // On Space down - Fire
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Calling a function to repeat while holding space down.
            // (Function to call, Start time (0 will fail so make it really small), the rate to re-call this function)
            InvokeRepeating("Fire", 0.000001f, firingRate);
        }

        // Upon space up
        if(Input.GetKeyUp(KeyCode.Space))
        {
            // Cancel the fire call
            CancelInvoke("Fire");
        }
    }

    void Fire()
    {
        // Create a new "Laser" projectile and move it upwards at a specified speed
        GameObject spawned_laser = Instantiate(Laser, transform.position, Quaternion.identity) as GameObject;
        spawned_laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
        // Make a sound when we fire
        AudioSource.PlayClipAtPoint(FireSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.GetComponent<Projectile>();
        // If the object we have collided with has a "Projectile" component attached to it.
        if (missile)
        {
            // Tell the missile its been hit
            missile.Hit();
            // Damage this ship!!
            Health -= missile.GetDamage();
            // Is the ship dead?
            if (Health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        LevelManager levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelmanager.LoadLevel("Win Screen");
        Destroy(gameObject);
    }
}
