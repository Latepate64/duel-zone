using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class KiposContraption : Creature
{
    public KiposContraption() : base("Kipo's Contraption", 6, 3000,
        Race.Xenoparts, Civilization.Fire)
    {
        AddAbilities(
            new TapAbility(
                new CardMovingChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(2000),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}