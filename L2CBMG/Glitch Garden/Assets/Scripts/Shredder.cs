using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Regardless of what enters this collider just destroy it.
        Destroy(collider.gameObject);
    }
}
