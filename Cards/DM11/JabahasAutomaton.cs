using Abilities.Static;
using ContinuousEffects.PowerModifying;

namespace Cards.DM11
{
    sealed class JabahasAutomaton : EvolutionCreature
    {
        public JabahasAutomaton() : base("Jabaha's Automaton", 5, 6000, Interfaces.Race.Xenoparts, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
