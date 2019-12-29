using UnityEngine;

namespace ShipComponents
{
    public class PowerProducer : MonoBehaviour
    {
        [SerializeField]
        private float powerProductionRate;
        
        /**
         * Returns how much power was produced
         */
        public float ProducePower(float time)
        {
            return powerProductionRate * time;
        }
    }
}