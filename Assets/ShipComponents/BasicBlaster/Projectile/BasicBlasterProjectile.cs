using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BasicBlasterProjectile : MonoBehaviour
{
    [SerializeField]
    private float ttl;

    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, ttl);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        var destructible = other.GetComponentInParent<Destructible>();
        if (destructible != null)
        {
            destructible.Damage(damage);
        }
        Destroy(gameObject);
    }
}
