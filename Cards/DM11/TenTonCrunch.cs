namespace Cards.DM11
{
    sealed class TenTonCrunch : Engine.Spell
    {
        public TenTonCrunch() : base("Ten-Ton Crunch", 4, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(3000));
        }
    }
}
