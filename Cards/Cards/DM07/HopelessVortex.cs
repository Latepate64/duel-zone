namespace Cards.Cards.DM07
{
    class HopelessVortex : Spell
    {
        public HopelessVortex() : base("Hopeless Vortex", 5, Engine.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOneOfYourOpponentsCreaturesEffect());
        }
    }
}
