using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM06
{
    class QTronicGargantua : EvolutionCreature
    {
        public QTronicGargantua() : base("Q-tronic Gargantua", 6, 9000, Subtype.Survivor, Civilization.Fire)
        {
            AddStaticAbilities(new CrewBreakerSubtypeEffect(Subtype.Survivor));
        }
    }
}
