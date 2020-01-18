using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject spacePrefab;
    
    private void Update()
    {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        foreach (var item in inventory.items)
        {
            var space = Instantiate(spacePrefab, transform);
            Instantiate(item.icon, space.transform);
        }
        
    }
}