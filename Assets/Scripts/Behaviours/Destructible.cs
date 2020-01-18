using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    private float currentHp;
    
    [SerializeField]
    private float initialHp;

    [SerializeField]
    private GameObject[] spawnOnDeath;
    
    void Start()
    {
        currentHp = initialHp;
    }

    public void Damage(float amount)
    {
        currentHp -= amount;
        if (currentHp <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        if (spawnOnDeath != null)
        {
            foreach (var toSpawn in spawnOnDeath)
            {
                Instantiate(toSpawn, transform.position, transform.rotation);                
            }
        }
    }
}
