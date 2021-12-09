using System;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IDamageDealer
    {
        [SerializeField]
        private float _speed;

        [SerializeField] 
        private int _damage;

        [SerializeField] private GameObject _fxExplosion;
        [SerializeField] private float _fxExplosionTimeLive = 1f;
        
        [SerializeField] private UnitBattleIdentity _battleIdentity;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public int Damage => _damage;

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }

        private void Update()
        {
            Move(_speed);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();

            if (damagableObject != null
                && damagableObject.BattleIdentity != BattleIdentity)
            {
                damagableObject.ApplyDamage(this);

                if (_fxExplosion && _fxExplosionTimeLive > 0)
                    Destroy(
                        Instantiate(_fxExplosion, gameObject.transform.localPosition, Quaternion.Euler(Vector3.zero),
                            gameObject.transform.parent), _fxExplosionTimeLive);
                // Удаляем изза недаобности
                Destroy(gameObject);
            }
        }

        protected abstract void Move(float speed);
    }
}
