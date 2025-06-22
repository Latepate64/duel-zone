using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM02;

public class PoisonWorm : Creature
{
    public PoisonWorm() : base("Poison Worm", 4, 4000, Race.ParasiteWorm, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PoisonWormEffect()));
    }
}
