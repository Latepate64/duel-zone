using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class AquaGrappler : Creature
{
    public AquaGrappler() : base("Aqua Grappler", 5, 3000, Race.LiquidPeople, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new AquaGrapplerEffect()));
    }
}
