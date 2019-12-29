using UnityEngine;

namespace ShipComponents
{
    public interface IWeapon
    {
        //Returns power spent
        float Fire(float time, float availablePower);
        
        void AimAt(Vector3 target, float time);
    }
}