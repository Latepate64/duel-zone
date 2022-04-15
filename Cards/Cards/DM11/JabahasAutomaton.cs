namespace Cards.Cards.DM11
{
    class JabahasAutomaton : EvolutionCreature
    {
        public JabahasAutomaton() : base("Jabaha's Automaton", 5, 6000, Engine.Subtype.Xenoparts, Engine.Civilization.Fire)
        {
            AddPowerAttackerAbility(4000);
            AddDoubleBreakerAbility();
        }
    }
}
