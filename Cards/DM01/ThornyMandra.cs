using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM01;

public sealed class ThornyMandra : Creature
{
    public ThornyMandra() : base("Thorny Mandra", 5, 4000, Race.TreeFolk, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ThornyMandraEffect()));
    }
}
