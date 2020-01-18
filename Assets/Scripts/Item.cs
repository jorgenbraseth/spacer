using System;
using UnityEngine;
using UnityEngine.UI;

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
        public string id;
        public string name;
        public Image icon;
        public GameObject lootPrefab;

        public ItemProperty[] properties = new ItemProperty[]{};

        public void Awake()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}