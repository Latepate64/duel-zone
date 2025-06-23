using ContinuousEffects;
using Interfaces;

namespace Cards;

public class DragonEvolutionCreature : Creature
{
    public DragonEvolutionCreature(string name, int manaCost, int power, Race race, params Civilization[] civilizations) : base(name, manaCost, power, race, civilizations)
    {
        Supertypes.Add(Supertype.Evolution);
        AddStaticAbilities(new DragonEvolutionEffect());
    }
}
