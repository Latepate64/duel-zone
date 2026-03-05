using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect
{
    public WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect();
    }

    public override string ToString()
    {
        return "When this creature would be destroyed, put it into your mana zone instead.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return IsSourceOfAbility(card);
    }
}
