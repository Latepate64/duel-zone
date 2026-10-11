using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class TornadoFlame : Spell
{
    public TornadoFlame() : base("Tornado Flame", 5, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new DestroyEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new MaxPowerFilter(4000),
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}