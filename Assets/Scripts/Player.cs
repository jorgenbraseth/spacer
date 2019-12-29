using ShipComponents;
using UnityEngine;

[RequireComponent(typeof(Spaceship))]
public class Player : MonoBehaviour
{
    
    private Spaceship _spaceship;
    public void Shooting(bool shooting)
    {
        _spaceship.shooting = shooting;
    }

    // Start is called before the first frame update
    private void Start()
    {
        _spaceship = GetComponentInChildren<Spaceship>();
    }

    internal void SetThrottle(float throttle)
    {
        _spaceship.throttle = throttle;
    }

    internal void Turn(float turning)
    {
        _spaceship.turning = turning;
    }

    public void aimAt(Vector3 mousePosInAimPlane)
    {
        _spaceship.aimPos = mousePosInAimPlane;
    }
}
