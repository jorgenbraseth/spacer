using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWhenInRange : MonoBehaviour
{
    public float range;
    public LayerMask targets;

    private EnemyShip ship;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<EnemyShip>();
    }

    // Update is called once per frame
    void Update()
    {
        var inRange = Physics.OverlapSphere(transform.position, range, targets);

        if (inRange.Length > 0)
        {
            ship.Shoot();
        }
        
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, range);
    }
}
