using ContinuousEffects.PowerModifying;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM12;

public sealed class AgiraTheWarlordCrawler : EvolutionCreature
{
    public AgiraTheWarlordCrawler() : base("Agira, the Warlord Crawler", 4,
        5500, Race.Gladiator, Race.EarthEater, Civilization.Light,
        Civilization.Water)
    {
        AddStaticAbilities(
            new EachOfYourOtherRacesGetsPowerEffect(
                Race.Gladiator,
                Race.EarthEater));
        AddTriggeredAbility(
            new WheneverOneOfYourRaceBlocksAbility(
                new YouMayDrawCardsEffect(1),
                Race.Gladiator,
                Race.EarthEater));
    }
}
