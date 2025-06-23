using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class IkazTheSpydroid : Creature
{
    public IkazTheSpydroid() : base("Ikaz, the Spydroid", 4, 4000, Race.Soltrooper, Civilization.Light)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new IkazTheSpydroidEffect()));
    }
}
