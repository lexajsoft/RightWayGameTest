using System;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Items
{
    public class ItemBase : MonoBehaviour, IPickupable
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.position += Vector3.down * _speed*Time.deltaTime;
        }

        public virtual void Pick(ISpaceship ship)
        {
            Destroy(gameObject);
        }
    }
}