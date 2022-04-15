using Cards.ContinuousEffects;
using Engine;

namespace Cards
{
    class EvolutionCreature : Creature
    {
        public EvolutionCreature(string name, int manaCost, int power, Subtype race, Civilization civilization) : base(name, manaCost, power, race, civilization)
        {
            Supertypes.Add(Supertype.Evolution);
            AddStaticAbilities(new RaceEvolutionEffect(race));
        }

        public EvolutionCreature(string name, int manaCost, int power, Subtype race1, Subtype race2, Civilization civilization1, Civilization civilization2) : base(name, manaCost, power, race1, race2, civilization1, civilization2)
        {
            Supertypes.Add(Supertype.Evolution);
            AddStaticAbilities(new RaceEvolutionEffect(race1, race2));
        }
    }

    class DragonEvolutionCreature : Creature
    {
        public DragonEvolutionCreature(string name, int manaCost, int power, Subtype race, params Civilization[] civilizations) : base(name, manaCost, power, race, civilizations)
        {
            Supertypes.Add(Supertype.Evolution);
            AddStaticAbilities(new DragonEvolutionEffect());
        }
    }
}
