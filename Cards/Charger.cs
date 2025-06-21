using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards;

abstract class Charger : Spell
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

