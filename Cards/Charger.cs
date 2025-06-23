using Interfaces;

namespace Cards;

public abstract class Charger : Spell
{
    protected Charger(string name, int manaCost, Civilization civilization) : base(name, manaCost, civilization)
    {
        AddAbilities(new ChargerAbility());
    }
}
