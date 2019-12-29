using System;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

namespace ShipComponents
{
    [RequireComponent(typeof(Rigidbody))]
    public class Spaceship : MonoBehaviour
    {
        private Rigidbody _rigidBody;
    
        [SerializeField]
        private float totalEnginePower;
    
        public float turnSpeedAcceleration;
        public float maxTurnSpeed;
        
        public float storedPower;

        public float turning;
        public float throttle;
        public bool shooting;
        public Vector3 aimPos;


        // Start is called before the first frame update
        void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _rigidBody.mass = TotalMass();
        }
        
        private float TotalMass()
        {
            return GetComponentsInChildren<ShipComponent>().Sum(component => component.Mass());
        }

        private void Thrust(float time)
        {
            if (throttle < 0.001) return;
            
            var engines = GetComponentsInChildren<Engine>();

            foreach (var engine in engines)
            {
                storedPower -= engine.Thrust(time, storedPower);                
            }
        }

        private float AvailablePower()
        {
            return storedPower;
        }

        private void Turn(float time)
        {
            var targetVelocity = maxTurnSpeed * turning * Vector3.up;
            _rigidBody.angularVelocity = Vector3.Lerp(_rigidBody.angularVelocity, targetVelocity, time * turnSpeedAcceleration);
        }

        private void Update()
        {
            var time = Time.deltaTime;
            ProduceAndStorePower(time);
            Thrust(time);
            Turn(time);
            Aim(time);
            Shoot(time);
        }

        private void Aim(float time)
        {
            var weapons = GetComponentsInChildren<IWeapon>();
            foreach (IWeapon weapon in weapons)
            {
                weapon.AimAt(aimPos, time);
            }
        }

        private void Shoot(float time)
        {
            if(!shooting) return;
            
            var weapons = GetComponentsInChildren<IWeapon>();
            foreach (var weapon in weapons)
            {
                storedPower -= weapon.Fire(time, AvailablePower());
            }    
        }

        private void ProduceAndStorePower(float time)
        {
            var powerProducers = GetComponentsInChildren<PowerProducer>();
            var producedPower = 0f;
            foreach (var producer in powerProducers)
            {
                producedPower += producer.ProducePower(time);
            }

            StorePower(producedPower);
        }

        private void StorePower(float amountToStore)
        {
            var powerCapacity = GetComponentsInChildren<PowerStorage>().Sum(store => store.PowerCapacity());
            storedPower = Math.Min(powerCapacity, storedPower + amountToStore);
        }
    }
}
