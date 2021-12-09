using System;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        [SerializeField] 
        private Health _health;

        [SerializeField] private Score _score;

        [SerializeField] private Droper _droper;
        
        [SerializeField] private Pickuper _pickuper;
        
        public UnityAction Die;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public Health Health => _health;
        
        public UnitBattleIdentity BattleIdentity => _battleIdentity;



        private void Start()
        {
            if (_shipController == null)
            {
                _shipController = GetComponent<ShipController>();
            }
            _shipController?.Init(this);

            if (_weaponSystem == null)
            {
                _weaponSystem = GetComponent<WeaponSystem>();
            }
            _weaponSystem?.Init(_battleIdentity);

            if (_health == null)
            {
                _health = GetComponent<Health>();
            }
            if (_health != null)
            {
                _health?.Init();
            }

            

            if (_score == null)
            {
                _score = GetComponent<Score>();
            }

            if (_score != null)
            {
                Die += _score.ApplyExp;
            }

            if (_droper == null)
            {
                _droper = GetComponent<Droper>();
            }
            if (_droper != null)
            {
                Die += _droper.DropItem;
            }

            if (_pickuper == null)
            {
                _pickuper = GetComponent<Pickuper>();
            }
            _pickuper?.Init(this);
            
            
        }

        public virtual void ApplyDamage(IDamageDealer damageDealer)
        {
            if (_health)
            {
                _health.Damage(damageDealer.Damage);
                if (!_health.IsLive())
                {
                    Die?.Invoke();
                    Destroy(gameObject);    
                }
            }
            else
            {
                Die?.Invoke();
                Destroy(gameObject);    
            }
            
        }
    }
}
