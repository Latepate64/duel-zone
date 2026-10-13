using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class MieleVizierOfLightning : Creature
{
    public MieleVizierOfLightning() : base("Miele, Vizier of Lightning", 3,
        1000, Race.Initiate, Civilization.Light)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new TapChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    ownerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCards
                )));
    }
}