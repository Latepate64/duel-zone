using System.Collections.Generic;

namespace Engine;

public class Spell : Card
{
    public Spell(bool tapped, List<Civilization> civilizations, int manaCost, string name) : base(tapped,
        civilizations, manaCost, name)
    {
    }

    public Spell(string name, int manaCost, List<Civilization> civilizations) : this(false, civilizations, manaCost,
        name)
    {
    }

    public Spell(Spell spell) : base(spell)
    {
    }

    public override Spell Copy()
    {
        return new Spell(this);
    }
}