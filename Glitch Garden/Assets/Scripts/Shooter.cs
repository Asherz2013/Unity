using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public GameObject Projectile, Gun;

    private GameObject ProjectileParent;

    void Start()
    {
        // Check there is a "Projectiles" gameobject
        ProjectileParent = GameObject.Find("Projectiles");

        // If its null
        if(!ProjectileParent)
        {
            // Create a new gameobject
            ProjectileParent = new GameObject("Projectiles");
        }
    }

    private void Fire()
    {
        // Create an instance of the projectile
        GameObject newProj = Instantiate(Projectile) as GameObject;
        // Attach it to the Parent in the scene
        newProj.transform.parent = ProjectileParent.transform;
        // Start it at the "Gun" position
        newProj.transform.position = Gun.transform.position;
    }
}
