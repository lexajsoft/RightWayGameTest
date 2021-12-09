using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.ShipControllers
{
    public abstract class ShipController : MonoBehaviour
    {
        protected Spaceship _spaceship;
        
        public virtual void Init(Spaceship spaceship)
        { 
            _spaceship = spaceship;
        }

        private void Update()
        {
            ProcessHandling(_spaceship.MovementSystem);
            ProcessFire(_spaceship.WeaponSystem);
        }
            
        protected abstract void ProcessHandling(MovementSystem movementSystem);
        protected abstract void ProcessFire(WeaponSystem fireSystem);
        
    }
}
