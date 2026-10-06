using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// You can summon this creature only if you have cast a spell this turn.
/// </summary>
public sealed class YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect
    : ContinuousEffect, ICannotUseCardEffect
{
    public YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect()
    {
    }

    public YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect(
        YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect effect)
        : base(effect)
    {
    }

    public bool Applies(ICard card, IGameState state)
    {
        throw new NotImplementedException();
    }

    public override IContinuousEffect Copy()
    {
        return new YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect(
            this);
    }
}
