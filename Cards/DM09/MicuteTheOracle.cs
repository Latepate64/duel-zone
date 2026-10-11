using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

sealed class MicuteTheOracle : Creature
{
    public MicuteTheOracle() : base("Micute, the Oracle", 5, 4000,
        Race.LightBringer, Civilization.Light)
    {
        AddTriggeredAbility(
            new WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(
                Race.Guardian,
                new TapChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    ownerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}