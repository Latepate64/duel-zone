using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class StratosphereGiant : Creature
{
    public StratosphereGiant() : base("Stratosphere Giant", 8, 13000, Race.Giant, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new StratosphereGiantEffect()));
        AddStaticAbilities(new TripleBreakerEffect());
    }
}
