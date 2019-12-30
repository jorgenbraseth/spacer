using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Lootable : MonoBehaviour
{
    public Item[] loot;
    private bool looted = false;

    private void OnCollisionEnter(Collision other)
    {
        Looter looter = other.gameObject.GetComponentInParent<Looter>();
        if (looter == null) return;

        Debug.Log("Looted");
        Destroy(gameObject);
        looter.inventory.Add(loot);
    }
}
