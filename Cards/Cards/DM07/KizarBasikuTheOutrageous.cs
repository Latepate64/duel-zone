using ContinuousEffects;

namespace Cards.Cards.DM07
{
    class KizarBasikuTheOutrageous : EvolutionCreature
    {
        public KizarBasikuTheOutrageous() : base("Kizar Basiku, the Outrageous", 5, 8500, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new StealthEffect(Engine.Civilization.Fire), new DoubleBreakerEffect());
        }
    }
}
