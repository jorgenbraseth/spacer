using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    public float ttl;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, ttl);
    }
}
