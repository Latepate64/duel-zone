using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class DarkReversal : Spell
{
    public DarkReversal() : base("Dark Reversal", 2, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new SalvageEffect(
                minimum: 1,
                maximum: 1,
                filter: new CreatureFilter(),
                excludeSource: false
        ));
    }
}