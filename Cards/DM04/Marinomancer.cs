using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM04;

public class Marinomancer : Creature
{
    public Marinomancer() : base("Marinomancer", 5, 2000, Race.CyberLord, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new MarinomancerEffect()));
    }
}
