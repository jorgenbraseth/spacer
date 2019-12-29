using UnityEngine;

namespace DefaultNamespace
{
    public class ShipComponent: MonoBehaviour
    {
        [SerializeField]
        private float mass;  
        
        public float Mass()
        {
            return mass;
        }
    }
}