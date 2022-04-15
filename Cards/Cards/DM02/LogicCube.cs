namespace Cards.Cards.DM02
{
    class LogicCube : Spell
    {
        public LogicCube() : base("Logic Cube", 3, Engine.Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.SearchSpellEffect());
        }
    }
}
