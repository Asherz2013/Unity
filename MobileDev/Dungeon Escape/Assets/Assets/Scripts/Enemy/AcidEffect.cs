using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 3.0f;

    [SerializeField]
    private float m_lifeTime = 5.0f;

    private void Start()
    {
        Destroy(gameObject, m_lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Move Constantly to the right
        transform.Translate(Vector3.right * m_moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            IDamagable hit = other.GetComponent<IDamagable>();
            if(hit !=null)
            {
                hit.Damage();
                Destroy(gameObject);
            }
        }
    }
}
