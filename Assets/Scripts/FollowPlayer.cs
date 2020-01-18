using ShipComponents;
using UnityEngine;

[RequireComponent(typeof(EnemyShip))]
public class FollowPlayer : MonoBehaviour
{
    public float detectionRadius = 30f;
    public float targetDistance = 10f;
    private EnemyShip ship;

    private void Start()
    {
        ship = GetComponent<EnemyShip>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] overlapSphere = Physics.OverlapSphere(gameObject.transform.position, detectionRadius);

        foreach (var collided in overlapSphere)
        {
            var spaceship = collided.GetComponentInParent<Spaceship>();
            if (spaceship != null)
            {
                ship.TurnTowards(spaceship.gameObject.transform.position);

                if ((ship.transform.position - spaceship.transform.position).magnitude > targetDistance)
                {
                    ship.Accelerate();
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(gameObject.transform.position, detectionRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, targetDistance);
    }
}
