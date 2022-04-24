using Cards.ContinuousEffects;
using Engine;

namespace Cards
{
    class EvolutionCreature : Creature
    {
        public EvolutionCreature(string name, int manaCost, int power, Race race, Civilization civilization) : base(name, manaCost, power, race, civilization)
        {
            Supertypes.Add(Supertype.Evolution);
            AddStaticAbilities(new RaceEvolutionEffect(race));
        }

        public EvolutionCreature(string name, int manaCost, int power, Race race1, Race race2, Civilization civilization1, Civilization civilization2) : base(name, manaCost, power, race1, race2, civilization1, civilization2)
        {
            Supertypes.Add(Supertype.Evolution);
            AddStaticAbilities(new RaceEvolutionEffect(race1, race2));
        }
    }

    class DragonEvolutionCreature : Creature
    {
        public DragonEvolutionCreature(string name, int manaCost, int power, Race race, params Civilization[] civilizations) : base(name, manaCost, power, race, civilizations)
        {
            Supertypes.Add(Supertype.Evolution);
            AddStaticAbilities(new DragonEvolutionEffect());
        }
    }

    class VortexEvolutionCreature : Creature
    {
        public VortexEvolutionCreature(string name, int manaCost, int power, Civilization civilization1, Civilization civilization2, Race race, Race bait1Race, Race bait2Race) : base(name, manaCost, power, race, civilization1, civilization2)
        {
            Supertypes.Add(Supertype.Evolution);
            AddStaticAbilities(new VortexEvolutionEffect(bait1Race, bait2Race));
        }
    }
}
