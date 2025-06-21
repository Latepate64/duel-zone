namespace Cards.DM03
{
    class LogicSphere : Engine.Spell
    {
        public LogicSphere() : base("Logic Sphere", 3, Engine.Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnSpellFromYourManaZoneToYourHandEffect());
        }
    }
}
