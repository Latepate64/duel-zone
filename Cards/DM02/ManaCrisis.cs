using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

sealed class ManaCrisis : Spell
{
    public ManaCrisis() : base("Mana Crisis", 4, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new ManaBurnEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                ownMana: false
        ));
    }
}