using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM07
{
    class KizarBasikuTheOutrageous : EvolutionCreature
    {
        public KizarBasikuTheOutrageous() : base("Kizar Basiku, the Outrageous", 5, 8500, Subtype.Initiate, Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new StealthEffect(Civilization.Fire), new DoubleBreakerEffect());
        }
    }
}
