using System;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private Rigidbody body;
    private WeaponPort[] weaponPorts;
    public float rotationSpeed = 10.1f;
    public float enginePower = 10.1f;

    public float weaponCooldown = 1f;
    private float nextShot = 0f;

    private void Start()
    {
         body = GetComponentInChildren<Rigidbody>();
         if (body == null)
         {
             throw new Exception("No RigidBody in enemy: "+gameObject.name);
         }

         weaponPorts = GetComponentsInChildren<WeaponPort>();
    }

    public void Shoot()
    {
        if (Time.time >= nextShot)
        {
            nextShot = Time.time + weaponCooldown;

            foreach (var weaponPort in weaponPorts)
            {
                weaponPort.Shoot();
            }
        }

    }

    public void TurnTowards(Vector3 target)
    {
        var direction = (target - transform.position);
        direction.Normalize();
        direction.y = 0;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    public void Accelerate()
    {

        body.AddForce(transform.forward * enginePower * Time.deltaTime);
    }
}
