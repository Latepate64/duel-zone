using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using StaticAbilities;
using CardFilters;

namespace Cards.DM09;

public sealed class AzaghastTyrantOfShadows : EvolutionCreature
{
    public AzaghastTyrantOfShadows() : base("Azaghast, Tyrant of Shadows", 7,
        9000, Race.DarkLord, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(
                Race.Ghost,
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new UntappedCreatureFilter(),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OpponentsCards
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
