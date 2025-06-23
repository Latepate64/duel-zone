using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class Marinomancer : Creature
{
    public Marinomancer() : base("Marinomancer", 5, 2000, Race.CyberLord, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new MarinomancerEffect()));
    }
}
