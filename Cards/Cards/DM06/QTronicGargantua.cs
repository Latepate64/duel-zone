using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class QTronicGargantua : EvolutionCreature
    {
        public QTronicGargantua() : base("Q-tronic Gargantua", 6, 9000, Engine.Race.Survivor, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new CrewBreakerRaceEffect(Engine.Race.Survivor));
        }
    }
}
