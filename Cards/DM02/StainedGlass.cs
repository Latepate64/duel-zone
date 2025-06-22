using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM02;

public class StainedGlass : Creature
{
    public StainedGlass() : base("Stained Glass", 3, 1000, Race.CyberVirus, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new StainedGlassEffect()));
    }
}
