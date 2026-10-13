using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;
using CardFilters;

namespace Cards.DM10;

public sealed class EarthRipperTalonOfRage : EvolutionCreature
{
    public EarthRipperTalonOfRage() : base("Earth Ripper, Talon of Rage", 4,
        6000, Race.BeastFolk, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ManaRecoveryAreaOfEffect(
                    filter: new TappedCardFilter(),
                    selectionRange: SelectionRange.OwnCards
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
