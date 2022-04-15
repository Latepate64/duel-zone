namespace Cards.Cards.DM06
{
    class PhantomDragonsFlame : Spell
    {
        public PhantomDragonsFlame() : base("Phantom Dragon's Flame", 3, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(2000));
        }
    }
}
