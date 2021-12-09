using System.Collections;
using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : MonoBehaviour
    {

        [SerializeField]
        private List<Weapon> _weapons;
        [SerializeField]
        private float _timeBoost = 3f;

        public UnityAction<bool> UpdateBoostStatus;

        private Coroutine _coroutineBoost;
        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
        }
        
        
        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

        public void NextBullet()
        {
            foreach (var weapon in _weapons)
            {
                weapon.NextBullet();   
            }
        }

        public void PrevBullet()
        {
            foreach (var weapon in _weapons)
            {
                weapon.PrevBullet();   
            }
        }

        public void SetBoostSpeedAtk()
        {
            foreach (var weapon in _weapons)
            {
                weapon.SetBoost();   
            }
            UpdateBoostStatus?.Invoke(true);
            if (_coroutineBoost != null)
            {
                StopCoroutine(_coroutineBoost);
            }
            _coroutineBoost = StartCoroutine(BoosterDelay());
        }
        public void DropBoostSpeedAtk()
        {
            foreach (var weapon in _weapons)
            {
                weapon.DropBoost();   
            }

            UpdateBoostStatus?.Invoke(false);
        }
        
        private IEnumerator BoosterDelay()
        {
            yield return new WaitForSeconds(_timeBoost);
            _coroutineBoost = null;
            DropBoostSpeedAtk();
        }
    }
}
