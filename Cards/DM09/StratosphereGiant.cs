using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM09;

public sealed class StratosphereGiant : Creature
{
    public StratosphereGiant() : base("Stratosphere Giant", 8, 13000, Race.Giant, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new StratosphereGiantEffect()));
        AddAbilities(new TripleBreakerAbility());
    }
}
