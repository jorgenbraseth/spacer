using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Lootable : MonoBehaviour
{
    public Item[] lootList;
    private List<Item> loot;
    private bool looted = false;

    private void Awake()
    {
        loot = new List<Item>();
        foreach (var lootItem in lootList)
        {
            loot.Add(Instantiate(lootItem));            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Looter looter = other.gameObject.GetComponentInParent<Looter>();
        if (looter == null) return;

        Destroy(gameObject);
        looter.inventory.Add(loot.ToArray());
    }
}
