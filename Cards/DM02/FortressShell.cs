using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class FortressShell : Creature
{
    public FortressShell() : base("Fortress Shell", 9, 5000, Race.ColonyBeetle,
        Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ManaBurnEffect(
                    minimum: 0,
                    maximum: 2,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
        )));
    }
}