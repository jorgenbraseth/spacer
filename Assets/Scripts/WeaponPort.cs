using UnityEngine;

public class WeaponPort : MonoBehaviour
{
    public GameObject projectile;

    public void Shoot()
    {
        Debug.Log("pew!");
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
