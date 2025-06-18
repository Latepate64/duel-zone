namespace Cards.Cards.DM06
{
    class ProclamationOfDeath : Engine.Spell
    {
        public ProclamationOfDeath() : base("Proclamation of Death", 4, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.OpponentSacrificeEffect());
        }
    }
}
