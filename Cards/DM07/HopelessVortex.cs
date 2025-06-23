namespace Cards.DM07
{
    sealed class HopelessVortex : Spell
    {
        public HopelessVortex() : base("Hopeless Vortex", 5, Interfaces.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOneOfYourOpponentsCreaturesEffect());
        }
    }
}
