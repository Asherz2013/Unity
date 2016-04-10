using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float Health = 100f;
    public GameObject Projectile;
    public float ProjectileSpeed = 10f;
    public float ShotsPerSecond = 0.5f;
    public int ScoreValue = 150;

    public AudioClip FireSound;
    public AudioClip DeathSound;

    private ScoreKeeper scorekeeper;

    void Start()
    {
        // Upon start find the "Score" text element and get the script attached to it.
        scorekeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        // Find the proability this enemy will shoot
        float probability = Time.deltaTime * ShotsPerSecond;
        // Check against a random betwee 0 and 1
        if(Random.value < probability)  Fire();
    }

    void Fire()
    {
        // make a "laser" object
        GameObject laser = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
        // Give it a velocity going down the screen
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ProjectileSpeed);
        // Make a sound when firing
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
            Death();
        }
    }

    void Death()
    {
        if (Health <= 0)
        {
            // Upon Death add the score value from this enemy to the Score Script
            scorekeeper.Score(ScoreValue);
            // Play a sound before we die
            AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            // Destroy this object
            Destroy(gameObject);
        }
    }
}
