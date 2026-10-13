using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class DaidalosGeneralOfFury : Creature
{
    public DaidalosGeneralOfFury() : base("Daidalos, General of Fury", 4, 11000,
        Race.DemonCommand, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OwnCards
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}