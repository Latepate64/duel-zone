namespace Cards.Cards.DM03
{
    class LogicSphere : Spell
    {
        public LogicSphere() : base("Logic Sphere", 3, Common.Civilization.Light)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.ReturnSpellFromYourManaZoneToYourHandEffect());
        }
    }
}
