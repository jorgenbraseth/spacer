using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public void Add(Item item)
    {
        var found = items.Find(i => i.id == item.id);
        if (found != null) return; //Idempotent add
        items.Add(item);
    }
    public void Add(Item[] toAdd)
    {
        foreach (var item in toAdd)
        {
            this.Add(item);
        }
    }
}
