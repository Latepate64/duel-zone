namespace Cards.DM02
{
    sealed class LogicCube : Spell
    {
        public LogicCube() : base("Logic Cube", 3, Interfaces.Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.SearchSpellEffect());
        }
    }
}
