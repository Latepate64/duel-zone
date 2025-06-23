using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

public sealed class StainedGlass : Creature
{
    public StainedGlass() : base("Stained Glass", 3, 1000, Race.CyberVirus, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new StainedGlassEffect()));
    }
}
