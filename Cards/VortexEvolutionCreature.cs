using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards;

public class VortexEvolutionCreature : Creature
{
    public VortexEvolutionCreature(string name, int manaCost, int power, Civilization civilization1, Civilization civilization2, Race race, Race bait1Race, Race bait2Race) : base(name, manaCost, power, race, civilization1, civilization2)
    {
        Supertypes.Add(Supertype.Evolution);
        AddStaticAbilities(new VortexEvolutionEffect(bait1Race, bait2Race));
    }
}
