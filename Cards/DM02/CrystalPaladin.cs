using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM02;

public sealed class CrystalPaladin : EvolutionCreature
{
    public CrystalPaladin() : base("Crystal Paladin", 4, 5000,
        Race.LiquidPeople, Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingAreaOfEffect(
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Hand,
                    filter: new BlockerFilter(),
                    selectionRange: SelectionRange.AllCards,
                    excludeSource: false
        )));
    }
}
