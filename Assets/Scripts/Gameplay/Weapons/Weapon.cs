using System.Collections;
using System.Collections.Generic;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.Weapons
{
    public class Weapon : MonoBehaviour
    {

        [SerializeField]
        private List<Projectile> _projectiles;

        private int indexProjectile = 0;
        
        [SerializeField]
        private Transform _barrel;

        [SerializeField]
        private float _cooldown;

        private bool _readyToFire = true;
        private UnitBattleIdentity _battleIdentity;

        private bool _boost = false;
        
        public void SetBoost()
        {
            _boost = true;
            _readyToFire = true;
        }
        
        public void DropBoost()
        {
            _boost = false;
        }

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }

        public void NextBullet()
        {
            indexProjectile = (indexProjectile + 1) % _projectiles.Count;
        }

        public void PrevBullet()
        {
            indexProjectile = (indexProjectile-1);
            if (indexProjectile < 0)
                indexProjectile = _projectiles.Count - 1;
        }
        
        public void TriggerFire()
        {
            if (!_readyToFire)
                return;
            
            var proj = Instantiate(_projectiles[indexProjectile], _barrel.position, _barrel.rotation);
            proj.Init(_battleIdentity);
            StartCoroutine(Reload(_cooldown));
        }

        
        
        private IEnumerator Reload(float cooldown)
        {
            _readyToFire = false;
            if (_boost)
            {
                yield return new WaitForSeconds(cooldown/2f);
            }
            else
            {
                yield return new WaitForSeconds(cooldown);
            }
            _readyToFire = true;
        }

    }
}
