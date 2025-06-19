using Effects.Continuous;

namespace Cards.Cards.DM11
{
    class JabahasAutomaton : EvolutionCreature
    {
        public JabahasAutomaton() : base("Jabaha's Automaton", 5, 6000, Engine.Race.Xenoparts, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
