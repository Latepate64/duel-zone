using ContinuousEffects;

namespace Cards.DM06
{
    class QTronicGargantua : EvolutionCreature
    {
        public QTronicGargantua() : base("Q-tronic Gargantua", 6, 9000, Interfaces.Race.Survivor, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new CrewBreakerRaceEffect(Interfaces.Race.Survivor));
        }
    }
}
