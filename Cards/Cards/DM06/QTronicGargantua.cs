using Common;

namespace Cards.Cards.DM06
{
    class QTronicGargantua : EvolutionCreature
    {
        public QTronicGargantua() : base("Q-tronic Gargantua", 6, 9000, Subtype.Survivor, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.CrewBreakerAbility(Subtype.Survivor));
        }
    }
}
