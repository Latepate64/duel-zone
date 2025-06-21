namespace Cards.DM07
{
    class HopelessVortex : Engine.Spell
    {
        public HopelessVortex() : base("Hopeless Vortex", 5, Interfaces.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOneOfYourOpponentsCreaturesEffect());
        }
    }
}
