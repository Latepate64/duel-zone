using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotAttackPlayers;

public class CivilizationCreaturesCannotAttackYouEffectFactory
    : IContinuousEffectWithCivilizationFactory
{
    public IContinuousEffect Create(Civilization civilization)
    {
        return new CivilizationCreaturesCannotAttackYouEffect(civilization);
    }
}