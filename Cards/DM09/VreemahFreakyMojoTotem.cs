using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using ContinuousEffects.AbilityAddingPowerModifying;
using CardFilters;
using StaticAbilities;

namespace Cards.DM09;

public sealed class VreemahFreakyMojoTotem : Creature
{
    public VreemahFreakyMojoTotem() : base("Vreemah, Freaky Mojo Totem", 5, 4000, Race.MysteryTotem,
        Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(
                new ContinuousEffectAddingEffect(
                    new EachCreatureGetsPowerAndAbilityEffect(
                        new RaceCreatureFilter(Race.BeastFolk),
                        2000,
                        new DoubleBreakerAbility()
                    ),
                    new UntilEndOfThisTurnDuration()
                )));
    }
}
