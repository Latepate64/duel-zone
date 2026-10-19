using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using StaticAbilities;
using CardFilters;

namespace Cards.DM04;

public sealed class BallomMasterOfDeath : EvolutionCreature
{
    public BallomMasterOfDeath() : base("Ballom, Master of Death", 8, 12000,
        Race.DemonCommand, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingAreaOfEffect(
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    filter: new NonCivilizationCreatureFilter(
                        Civilization.Darkness),
                    selectionRange: SelectionRange.AllCards,
                    excludeSource: false
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
