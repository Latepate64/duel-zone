using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.Promo;

sealed class Gigagrax : Creature
{
    public Gigagrax() : base("Gigagrax", 8, 5000, Race.Chimera,
        Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new DestroyEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}