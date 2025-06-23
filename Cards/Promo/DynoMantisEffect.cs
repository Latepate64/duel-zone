using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.Promo;

public sealed class DynoMantisEffect : ContinuousEffect, IBreaksAdditionalShieldsEffect
{
    public override IContinuousEffect Copy()
    {
        return new DynoMantisEffect();
    }

    public int GetAmount(IGame game, ICreature creature)
    {
        return creature.Owner == Controller && !IsSourceOfAbility(creature) && creature.Power >= 5000 ? 1 : 0;
    }

    public override string ToString()
    {
        return "Each of your other creatures in the battle zone that has power 5000 or more breaks one more shield.";
    }
}
