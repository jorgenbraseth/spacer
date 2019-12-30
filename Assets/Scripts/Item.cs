using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ItemProperty
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public int value;
    }
    
    

    [CreateAssetMenu(menuName = "Spacer/Lootable Item")]
    public class Item: ScriptableObject
    {
        private static int itemId = 0;
        
        public int id;
        public string name;
        public Sprite icon;
        public GameObject lootPrefab;

        public ItemProperty[] properties = new ItemProperty[]{};

        private void Awake()
        {
            id = itemId++;
        }
    }
}