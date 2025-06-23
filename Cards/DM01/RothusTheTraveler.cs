using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class RothusTheTraveler : Creature
{
    public RothusTheTraveler() : base("Rothus, the Traveler", 4, 4000, Race.Armorloid, Civilization.Fire)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new RothusTheTravelerEffect()));
    }
}
