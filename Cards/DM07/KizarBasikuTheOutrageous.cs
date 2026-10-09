using Abilities.Static;
using ContinuousEffects.Unblockable;

namespace Cards.DM07
{
    sealed class KizarBasikuTheOutrageous : EvolutionCreature
    {
        public KizarBasikuTheOutrageous() : base("Kizar Basiku, the Outrageous", 5, 8500, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new StealthEffect(Interfaces.Civilization.Fire));
            AddAbilities(new DoubleBreakerAbility());
        }
    }

    internal class DoubleBreakerEffect
    {
        public DoubleBreakerEffect()
        {
        }
    }
}
