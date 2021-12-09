using System;
using Gameplay.Helpers;
using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        public static PlayerShipController Player;

        public void Start()
        {
            Player = this;
        }

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LateralMovement(Input.GetAxis("Horizontal") * Time.deltaTime,false);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFire();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                fireSystem.PrevBullet();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                fireSystem.NextBullet();
            }
        }

        public override void Init(Spaceship spaceship)
        {
            base.Init(spaceship);
            _spaceship.Die = GlobalParams.Instance.OnDiePlayer;
            _spaceship.Health.Changed = GlobalParams.Instance.UpdateBarHP;
            _spaceship.WeaponSystem.UpdateBoostStatus = GlobalParams.Instance.SetBoostStatus;
        }
    }
}
