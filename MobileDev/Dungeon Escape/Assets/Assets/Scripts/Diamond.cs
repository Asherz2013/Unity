using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int _diamondsToAdd = 1;

    // OnTriggerEnter to collect
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for the player
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player)
            {
                // Add for # diamonds
                player.AddGems(_diamondsToAdd);
                // Destroy :)
                Destroy(gameObject);
            }
        }
    }
}
