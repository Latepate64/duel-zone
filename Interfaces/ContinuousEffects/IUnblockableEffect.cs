using Interfaces.Zones;

namespace Interfaces.ContinuousEffects
{
    public interface IUnblockableEffect : IContinuousEffect
    {
        bool CannotBeBlocked(ICreature attacker, ICreature blocker,
            IAttackable targetOfAttack, IBattleZone battleZone);
    }
}
