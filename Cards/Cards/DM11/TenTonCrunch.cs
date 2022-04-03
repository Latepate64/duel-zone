namespace Cards.Cards.DM11
{
    class TenTonCrunch : Spell
    {
        public TenTonCrunch() : base("Ten-Ton Crunch", 4, Common.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(3000));
        }
    }
}
