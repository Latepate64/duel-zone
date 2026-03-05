using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class EarthRipperTalonOfRage : EvolutionCreature
{
    public EarthRipperTalonOfRage() : base("Earth Ripper, Talon of Rage", 4, 6000, Race.BeastFolk, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new EarthRipperTalonOfRageEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
