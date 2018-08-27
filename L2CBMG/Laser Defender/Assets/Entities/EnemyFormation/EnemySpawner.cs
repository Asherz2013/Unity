using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    public GameObject EnemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float Speed = 5f;
    public float spawnDelay = 0.5f;

    private bool movingRight = false;
    private float xMax;
    private float xMin;

    // Use this for initialization
    void Start()
    {
        // Distance from Enemy to Camera
        float distance = transform.position.z - Camera.main.transform.position.z;
        // Calculate the edges of the screen
        Vector3 leftBoundry = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightBoundry = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        // Apply the boundaries to the class Min and Max
        xMax = rightBoundry.x;
        xMin = leftBoundry.x;

        SpawnUntilFull();
    }
    
    // Update is called once per frame
    void Update()
    {
        // If this bool is true we are moving right
        if (movingRight) transform.position += Vector3.right * Speed * Time.deltaTime;
        else transform.position += Vector3.left * Speed * Time.deltaTime;

        // Find the right edge of the "EnemyFormation"
        float rightEdgeOfFormation = transform.position.x + (width / 2);
        // Find the left edge of the "EnemyFormation"
        float leftEdgeOfFormation = transform.position.x - (width / 2);
        // If they are outside the edge then they should flip the direction
        if (leftEdgeOfFormation < xMin) movingRight = true;
        else if (rightEdgeOfFormation > xMax) movingRight = false;

        if(AllMembersDead())
        {
            SpawnUntilFull();
        }
    }
    
    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            // Instantly create a new enemy from a prefab at the origin of the relevant "Position"
            GameObject enemy = Instantiate(EnemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
            // Making the newly spawned enemy be in the "EnemyFormation" hierachy under the relevant "Position".
            enemy.transform.parent = freePosition;
        }
        if(NextFreePosition()) Invoke("SpawnUntilFull", spawnDelay);
    }

    Transform NextFreePosition()
    {
        // Loop through all "position" nodes in the tree to see if they have ships in them.
        foreach (Transform childPosition in transform)
        {
            if (childPosition.childCount == 0) return childPosition;
        }
        return null;
    }

    bool AllMembersDead()
    {
        // Loop through all "position" nodes in the tree to see if they have ships in them.
        foreach(Transform childPosition in transform)
        {
            if (childPosition.childCount > 0) return false;
        }
        return true;
    }
}
