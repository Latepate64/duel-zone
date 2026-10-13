using OneShotEffects;
using Abilities;
using Interfaces;
using CardFilters;

namespace Cards.DM06;

sealed class RikabusScrewdriver : Creature
{
    public RikabusScrewdriver() : base("Rikabu's Screwdriver", 2, 1000,
        Race.Xenoparts, Civilization.Fire)
    {
        AddAbilities(
            new TapAbility(
                new CardMovingChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new BlockerFilter(),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OpponentsCards
                )));
    }
}