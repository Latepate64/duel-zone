using ContinuousEffects;

namespace Cards.DM07
{
    class KizarBasikuTheOutrageous : EvolutionCreature
    {
        public KizarBasikuTheOutrageous() : base("Kizar Basiku, the Outrageous", 5, 8500, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new StealthEffect(Interfaces.Civilization.Fire), new DoubleBreakerEffect());
        }
    }
}
