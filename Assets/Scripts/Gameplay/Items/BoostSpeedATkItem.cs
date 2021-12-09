using Gameplay.Spaceships;

namespace Gameplay.Items
{
    public class BoostSpeedATkItem : ItemBase
    {
        public override void Pick(ISpaceship ship)
        {
            base.Pick(ship);
            ship.WeaponSystem.SetBoostSpeedAtk();
        }
    }
}