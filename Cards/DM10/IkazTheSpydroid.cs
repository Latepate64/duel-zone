using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM10;

public sealed class IkazTheSpydroid : Creature
{
    public IkazTheSpydroid() : base("Ikaz, the Spydroid", 4, 4000, Race.Soltrooper, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new IkazTheSpydroidEffect()));
    }
}
