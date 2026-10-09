using Abilities.Static;

namespace Cards.DM06
{
    sealed class QTronicGargantua : EvolutionCreature
    {
        public QTronicGargantua() : base("Q-tronic Gargantua", 6, 9000, Interfaces.Race.Survivor, Interfaces.Civilization.Fire)
        {
            AddAbilities(new CrewBreakerRaceAbility(Interfaces.Race.Survivor));
        }
    }
}
