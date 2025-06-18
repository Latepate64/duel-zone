using System.Collections.Generic;

namespace Engine;

public class Spell(bool tapped, List<Civilization> civilizations, int manaCost, string name) : Card(tapped,
    civilizations, manaCost, name)
{
    public Spell(string name, int manaCost, List<Civilization> civilizations) : this(false, civilizations, manaCost,
        name)
    {
    }
}