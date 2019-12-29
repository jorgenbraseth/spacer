using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tumble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere;
    }
}
