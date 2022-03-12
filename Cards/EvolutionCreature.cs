using Cards.StaticAbilities;
using Common;

namespace Cards
{
    class EvolutionCreature : Creature
    {
        public EvolutionCreature(string name, int manaCost, int power, Subtype race, params Civilization[] civilizations) : base(name, manaCost, power, race, civilizations)
        {
            Supertypes.Add(Supertype.Evolution);
            AddAbilities(new EvolutionAbility(race));
        }
    }
}
