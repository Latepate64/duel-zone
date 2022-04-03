using Common;

namespace Cards.Cards.DM11
{
    class JabahasAutomaton : EvolutionCreature
    {
        public JabahasAutomaton() : base("Jabaha's Automaton", 5, 6000, Subtype.Xenoparts, Civilization.Fire)
        {
            AddPowerAttackerAbility(4000);
            AddDoubleBreakerAbility();
        }
    }
}
