using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public GameObject Projectile, Gun;

    private GameObject ProjectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

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

        animator = GameObject.FindObjectOfType<Animator>();
        SetMyLaneSpawner();
    }

    void Update()
    {
        if(isAttackerAHeadInLane())
        {
            animator.SetBool("IsAttacking", true);
            return;
        }
        animator.SetBool("IsAttacking", false);
    }

    // Look through all spawners, and set myLaneSpawner if found;
    void SetMyLaneSpawner()
    {
        // Find all "Spawners" in the scene
        Spawner[] SpawnerArray = GameObject.FindObjectsOfType<Spawner>();

        // Loop through them all
        foreach (Spawner thisSpawner in SpawnerArray)
        {
            // If they have the same Y pos then they are in the same lane.
            if(thisSpawner.transform.position.y == transform.position.y)
            {
                // Set the spawner
                myLaneSpawner = thisSpawner;
                // Break out
                return;
            }
        }

        // We can't find a spawner!
        Debug.LogError(name + " can't find spawner in lane.");
    }

    bool isAttackerAHeadInLane()
    {
        // If there are no childen in the lane then we can return false
        if (myLaneSpawner.transform.childCount <= 0) return false;
        
        // If there are attackers, are they in front of me?
        foreach(Transform attackers in myLaneSpawner.transform)
        {
            // And as long as they are to the right of me, return true
            if (attackers.transform.position.x > transform.position.x) return true;
        }

        // There are some attackers behind me so just return false as I can't turn and kill them
        return false;
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
