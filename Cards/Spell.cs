using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards;

class Spell : Engine.Spell
{
    protected Spell(string name, int manaCost, Civilization civilization) : base(name, manaCost, [civilization])
    {
    }

    protected Spell(string name, int manaCost, Civilization civilization1, Civilization civilization2) : base(name,
        manaCost, [civilization1, civilization2])
    {
    }

    /// <summary>
    /// Adds a spell ability for each one-shot effect provided.
    /// </summary>
    /// <param name="oneShotEffects"></param>
    protected void AddSpellAbilities(params IOneShotEffect[] oneShotEffects)
    {
        AddAbilities(oneShotEffects.Select(x => new SpellAbility(x)).ToArray());
    }
}

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

