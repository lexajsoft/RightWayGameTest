using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Items
{
    public class HPItem : ItemBase
    {
        [SerializeField, Range(0.1f,1f)] private float _procentHeal = 0.25f;
        public override void Pick(ISpaceship ship)
        {
            base.Pick(ship);
            ship.Health.Heal((int) (ship.Health.HpMax * _procentHeal));
        }
    }
}