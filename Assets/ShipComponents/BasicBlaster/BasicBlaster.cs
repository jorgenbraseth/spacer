using DefaultNamespace;
using ShipComponents;
using UnityEngine;

public class BasicBlaster : ShipComponent, IWeapon
{

    [SerializeField]
    private float rateOfFire;
    private float nextShotTime;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float powerPerShot;

    [SerializeField]
    private Transform barrelMouth;
    
    [SerializeField]
    private Transform turret;
    
    private void Awake()
    {
        nextShotTime = Time.time;
    }

    public float Fire(float time, float availablePower)
    {
        if (nextShotTime <= Time.time && availablePower >= powerPerShot)
        {
            Shoot();
            nextShotTime = Time.time + rateOfFire;
            return powerPerShot;
        }

        return 0;
    }

    public void AimAt(Vector3 target, float time)
    {
        turret.LookAt(target);
    }

    private void Shoot()
    {
        Instantiate(projectile, barrelMouth.position, barrelMouth.rotation);
    }
}
