using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

sealed class LogicCube : Spell
{
    public LogicCube() : base("Logic Cube", 3, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new SearchEffect(
                reveal: true,
                filter: new SpellFilter()
        ));
    }
}