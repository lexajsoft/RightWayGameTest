    using System;
    using Gameplay.Spaceships;
    using UnityEngine;
    using UnityEngine.Events;

    public class Pickuper : MonoBehaviour
    {
        private ISpaceship _spaceship; 
        private UnityAction PickUp_HP;
        private UnityAction PickUp_BoosterSpeedATK;

        public void Init(ISpaceship spaceship)
        {
            _spaceship = spaceship;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.GetComponent<IPickupable>();
            if (item != null)
            {
                item.Pick(_spaceship);
            }
        }
    }
