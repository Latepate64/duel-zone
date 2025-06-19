using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects;

public class WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect
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

    protected override bool Applies(Creature card, IGame game)
    {
        return IsSourceOfAbility(card);
    }
}
