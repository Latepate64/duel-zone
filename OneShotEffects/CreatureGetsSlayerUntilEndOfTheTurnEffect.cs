using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace OneShotEffects;

public class CreatureGetsSlayerUntilEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public CreatureGetsSlayerUntilEndOfTheTurnEffect(CreatureGetsSlayerUntilEndOfTheTurnEffect effect) : base(effect)
    {
    }

    public CreatureGetsSlayerUntilEndOfTheTurnEffect(ICard card) : base(
        card, new StaticAbility(new ThisCreatureHasSlayerEffect()))
    {
    }

    public override IContinuousEffect Copy()
    {
        return new CreatureGetsSlayerUntilEndOfTheTurnEffect(this);
    }

    public override string ToString()
    {
        return "This creature gets \"slayer\" until the end of the turn.";
    }
}