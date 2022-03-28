using Common;

namespace Cards.Cards.DM07
{
    class HopelessVortex : Spell
    {
        public HopelessVortex() : base("Hopeless Vortex", 5, Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOneOfYourOpponentsCreaturesEffect());
        }
    }
}
