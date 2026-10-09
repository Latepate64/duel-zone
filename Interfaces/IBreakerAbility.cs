using Interfaces.Zones;

namespace Interfaces;

public interface IBreakerAbility : IStaticAbility
{
    int GetAmount(ICreature creature, IBattleZone battleZone);
}

