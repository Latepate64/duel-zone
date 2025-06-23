namespace Cards.DM06
{
    sealed class PhantomDragonsFlame : Spell
    {
        public PhantomDragonsFlame() : base("Phantom Dragon's Flame", 3, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(2000));
        }
    }
}
