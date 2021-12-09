using System;
using System.Security.Cryptography;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class EnemyKamikadzeShipController : ShipController
    {
        [SerializeField] private float _distanceExplosion = 5f;
        [SerializeField] private float _ignoreByPosY = 3f;
        [SerializeField] private float _multiSpeed = 2f;
        
        private PlayerShipController _target;

        private void Start()
        {
            _target = PlayerShipController.Player;
        }

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            if (_target != null)
            {
                if (transform.position.y - _ignoreByPosY > _target.transform.position.y)
                {
                    movementSystem.MoveToTarget(_target.transform, Time.deltaTime * _multiSpeed);
                }
                else
                {
                    movementSystem.LongitudinalMovement(Time.deltaTime);

                }

            }
            else
            {
                movementSystem.LongitudinalMovement(Time.deltaTime);
            }


        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (_target)
            {
                if (Vector3.Distance(_target.transform.position, gameObject.transform.position) <= _distanceExplosion)
                {
                    fireSystem.TriggerFire();
                    Destroy(gameObject);
                }
            }
        }
    }
}
