using Abilities.Static;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class CreatureGetsSlayerUntilEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public CreatureGetsSlayerUntilEndOfTheTurnEffect(CreatureGetsSlayerUntilEndOfTheTurnEffect effect) : base(effect)
    {
    }

    public CreatureGetsSlayerUntilEndOfTheTurnEffect(ICard card) : base(
        card, new SlayerAbility())
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