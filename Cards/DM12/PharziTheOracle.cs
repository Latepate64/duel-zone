using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM12;

sealed class PharziTheOracle : Creature
{
    public PharziTheOracle() : base("Pharzi, the Oracle", 2, 1000,
        Race.LightBringer, Civilization.Light)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new SpellFilter(),
                    source: ZoneType.Graveyard,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OwnCards
        )));
    }
}