namespace Cards.Cards.DM02
{
    class LogicCube : Spell
    {
        public LogicCube() : base("Logic Cube", 3, Common.Civilization.Light)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.SearchSpellEffect());
        }
    }
}
