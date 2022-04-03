namespace Cards.Cards.DM03
{
    class LogicSphere : Spell
    {
        public LogicSphere() : base("Logic Sphere", 3, Common.Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnSpellFromYourManaZoneToYourHandEffect());
        }
    }
}
