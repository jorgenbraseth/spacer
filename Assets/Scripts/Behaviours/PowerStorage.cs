using UnityEngine;

namespace ShipComponents
{
    public class PowerStorage : MonoBehaviour
    {
        [SerializeField]
        private float powerCapacity;

        public float PowerCapacity()
        {
            return powerCapacity;
        }
    }
}