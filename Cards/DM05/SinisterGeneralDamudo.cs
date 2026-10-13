using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM05;

sealed class SinisterGeneralDamudo : Creature
{
    public SinisterGeneralDamudo() : base("Sinister General Damudo", 6, 5000,
        Race.DarkLord, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new DestroyAreaOfEffect(
                    filter: new MaxPowerFilter(3000),
                    selectionRange: SelectionRange.AllCards,
                    excludeSource: false)));
    }
}