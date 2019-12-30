using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tumble : MonoBehaviour
{
    public float maxSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * maxSpeed;
    }
}
