using UnityEngine;

public class Destructible : MonoBehaviour
{
    private float currentHp;
    
    [SerializeField]
    private float initialHp;

    [SerializeField]
    private GameObject spawnOnDeath;
    
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
        if (spawnOnDeath != null)
        {
            Instantiate(spawnOnDeath, transform.position, transform.rotation);
        }
        Destroy(gameObject);
        
    }
}
