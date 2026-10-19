using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11;

sealed class AquaTrickster : WaveStrikerCreature
{
    public AquaTrickster() : base("Aqua Trickster", 2, 1000, Race.LiquidPeople,
        Civilization.Water)
    {
        AddWaveStrikerAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new TapChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    ownerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCards
                )));
    }
}