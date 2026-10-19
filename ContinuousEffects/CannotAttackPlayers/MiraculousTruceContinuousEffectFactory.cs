using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotAttackPlayers;

public class MiraculousTruceContinuousEffectFactory
    : IContinuousEffectWithCivilizationFactory
{
    public IContinuousEffect Create(Civilization civilization)
    {
        return new MiraculousTruceContinuousEffect(civilization);
    }
}