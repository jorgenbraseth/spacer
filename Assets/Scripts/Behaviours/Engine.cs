using UnityEngine;

namespace ShipComponents
{
    public class Engine : MonoBehaviour
    {
        [SerializeField]
        private float thrust;
        [SerializeField]
        private float powerConsumption;
        
        private Spaceship ship;
        private ParticleSystem trail;
        
        public float Thrust(float time, float availablePower)
        {
            var neededPower = powerConsumption * time;
            if (neededPower <= availablePower)
            {
                ship.GetComponent<Rigidbody>().AddForce(time * thrust * 1000f * ship.transform.forward);
                On();
                return neededPower;
            }
            return 0;
        }
        private void Awake()
        {
            ship = GetComponentInParent<Spaceship>();
            trail = GetComponentInChildren<ParticleSystem>();
        }
        
        private void On()
        {
            var emissionModule = trail.emission;
            emissionModule.enabled = true;
        }

        private void Off()
        {
            var emissionModule = trail.emission;
            emissionModule.enabled = false;
        }
        private void LateUpdate()
        {
            Off();
        }
    }
    
    
}