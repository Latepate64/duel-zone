using Engine;
using Engine.Abilities;

namespace Cards;

abstract class Charger : Engine.Spell
{
    protected Charger(string name, int manaCost, Civilization civilization) : base(name, manaCost, civilization)
    {
        AddAbilities(new ChargerAbility());
    }
}

class ChargerAbility : StaticAbility
{
    public ChargerAbility() : base(new ContinuousEffects.ThisSpellHasChargerEffect())
    {
        FunctionZone = ZoneType.SpellStack;
    }
}

