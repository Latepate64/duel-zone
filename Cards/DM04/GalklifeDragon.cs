using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;
using CardFilters;

namespace Cards.DM04;

public sealed class GalklifeDragon : Creature
{
    public GalklifeDragon() : base("Galklife Dragon", 7, 6000,
        Race.ArmoredDragon, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingAreaOfEffect(
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    filter: new MultiFilter(
                        new CivilizationCreatureFilter(Civilization.Light),
                        new MaxPowerFilter(4000)
                    ),
                    selectionRange: SelectionRange.AllCards,
                    excludeSource: false
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
