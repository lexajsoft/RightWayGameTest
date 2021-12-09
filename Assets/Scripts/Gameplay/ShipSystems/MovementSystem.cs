using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class MovementSystem : MonoBehaviour
    {

        [SerializeField]
        private float _lateralMovementSpeed;
        
        [SerializeField]
        private float _longitudinalMovementSpeed;

        [SerializeField] private float _speedToTarget = 1;

        public void LateralMovement(float amount, bool ignoreGameArea=true)
        {
            if (ignoreGameArea)
            {
                Move(amount * _lateralMovementSpeed, Vector3.right);
            }
            else
            {
                Vector3 vec = transform.position;
                if (Helpers.GameAreaHelper.IsInGameplayArea(
                    vec + amount * _lateralMovementSpeed * Vector3.right.normalized, new Vector2(2, 2)))
                {
                    Move(amount * _lateralMovementSpeed, Vector3.right);
                }
            }
            
            
        }

        public void LongitudinalMovement(float amount)
        {
            Move(amount * _longitudinalMovementSpeed, Vector3.up);
        }

        private void Move(float amount, Vector3 axis)
        {
            
            transform.Translate(amount * axis.normalized);
            
        }

        public void MoveToTarget(Transform target, float amount)
        {
            var vec = gameObject.transform.position - target.position;
             
            transform.Translate(amount * vec.normalized * _speedToTarget);

        }
    }
}
