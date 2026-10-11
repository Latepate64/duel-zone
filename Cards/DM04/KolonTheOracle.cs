using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM04;

sealed class KolonTheOracle : Creature
{
    public KolonTheOracle() : base("Kolon, the Oracle", 4, 1000,
        Race.LightBringer, Civilization.Water)
    {
        AddShieldTrigger();
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new TapChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    ownerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}