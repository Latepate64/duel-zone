using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class QTronicGargantua : EvolutionCreature
    {
        public QTronicGargantua() : base("Q-tronic Gargantua", 6, 9000, Engine.Subtype.Survivor, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new CrewBreakerSubtypeEffect(Engine.Subtype.Survivor));
        }
    }
}
