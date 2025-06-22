using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards;

public class SilentSkillCreature : Creature
{
    public SilentSkillCreature(string name, int manaCost, int power, Race race, Civilization civilization) : base(name, manaCost, power, race, civilization)
    {
    }

    public SilentSkillCreature(string name, int manaCost, int power, Race race, Civilization civilization1, Civilization civilization2) : base(name, manaCost, power, race, civilization1, civilization2)
    {
    }

    protected void AddSilentSkillAbility(IOneShotEffect effect)
    {
        AddAbilities(new SilentSkillAbility(effect));
    }
}

