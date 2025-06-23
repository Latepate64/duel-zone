using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class TimeScout : Creature
{
    public TimeScout() : base("Time Scout", 2, 1000, Race.Merfolk, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TimeScoutEffect()));
    }
}
