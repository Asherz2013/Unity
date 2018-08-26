using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Variable to determine if the damage function can be called
    bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        IDamagable hit = other.GetComponent<IDamagable>();
        if(hit != null && _canDamage)
        {
            hit.Damage();
            _canDamage = false;
            StartCoroutine(ResetDamage());
        }
    }

    // Coroutine
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);

        _canDamage = true;
    }

    
}
