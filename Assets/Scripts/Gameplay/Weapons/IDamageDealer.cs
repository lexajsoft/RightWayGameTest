
namespace Gameplay.Weapons
{
    public interface IDamageDealer
    {
        
        UnitBattleIdentity BattleIdentity { get; }

        int Damage { get; }

    }
}
