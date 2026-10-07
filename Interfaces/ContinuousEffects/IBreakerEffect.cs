using Interfaces.Zones;

namespace Interfaces.ContinuousEffects
{
    public interface IBreakerEffect : IContinuousEffect
    {
        int GetAmount(ICreature creature, IBattleZone battleZone);
    }
}
