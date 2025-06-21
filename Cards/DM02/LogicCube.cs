namespace Cards.DM02
{
    class LogicCube : Engine.Spell
    {
        public LogicCube() : base("Logic Cube", 3, Interfaces.Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.SearchSpellEffect());
        }
    }
}
