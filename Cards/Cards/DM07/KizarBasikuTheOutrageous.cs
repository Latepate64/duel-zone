using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class KizarBasikuTheOutrageous : EvolutionCreature
    {
        public KizarBasikuTheOutrageous() : base("Kizar Basiku, the Outrageous", 5, 8500, Engine.Subtype.Initiate, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new StealthEffect(Engine.Civilization.Fire), new DoubleBreakerEffect());
        }
    }
}
