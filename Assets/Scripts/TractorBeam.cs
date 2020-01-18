using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    public float radius;
    public float force;
    public LayerMask pullsIn;
    
    private void Update()
    {
        var myPos = transform.position;
        var lootInRange = Physics.OverlapSphere(myPos, radius, pullsIn);
        
        foreach (var loot in lootInRange)
        {
            var lootGameObject = loot.gameObject;
            var lootPos = lootGameObject.transform.position;
            var rb = lootGameObject.GetComponentInParent<Rigidbody>();
            var direction = (myPos-lootPos);
            var distance = direction.magnitude;
//            rb.AddForce(direction * (1/distance*distance) * force * Time.deltaTime);
            rb.velocity = Vector3.Lerp(rb.velocity, force/(distance*distance) * direction.normalized , Time.deltaTime);
            
            Debug.DrawLine(myPos, lootPos);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
