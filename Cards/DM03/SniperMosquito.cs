using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM03;

sealed class SniperMosquito : Creature
{
    public SniperMosquito() : base("Sniper Mosquito", 1, 2000, Race.GiantInsect,
        Civilization.Nature)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new ManaRecoveryEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                selectionRange: SelectionRange.OwnCreatures
        )));
    }
}