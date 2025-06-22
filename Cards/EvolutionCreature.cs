using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards;

public class EvolutionCreature : Creature
{
    public EvolutionCreature(string name, int manaCost, int power, Race race, Civilization civilization) : base(
        name, manaCost, power, race, civilization)
    {
        Supertypes.Add(Supertype.Evolution);
        AddStaticAbilities(new RaceEvolutionEffect(race));
    }

    public EvolutionCreature(string name, int manaCost, int power, Race race1, Race race2, Civilization civilization1,
        Civilization civilization2) : base(name, manaCost, power, [race1, race2], civilization1, civilization2)
    {
        Supertypes.Add(Supertype.Evolution);
        AddStaticAbilities(new RaceEvolutionEffect(race1, race2));
    }
}
