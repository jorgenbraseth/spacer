using UnityEngine;

public class RotateSkyWithMovement : MonoBehaviour
{
    public float magnitude = 1f;

    private Vector3 prevPos;

    private void Start()
    {
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var posDiff = pos - prevPos;
        prevPos = pos;
        var rot = new Vector3(posDiff.z, 0, -posDiff.x);
        transform.Rotate(rot * magnitude, Space.World);
    }
}
