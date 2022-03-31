using Cards.ContinuousEffects;
using Common;

namespace Cards
{
    class EvolutionCreature : Creature
    {
        public EvolutionCreature(string name, int manaCost, int power, Subtype race, params Civilization[] civilizations) : base(name, manaCost, power, race, civilizations)
        {
            Supertypes.Add(Supertype.Evolution);
            AddStaticAbilities(new RaceEvolutionEffect(new Engine.TargetFilter(), race));
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
