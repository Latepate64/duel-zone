namespace Cards.Cards.DM06
{
    class ProclamationOfDeath : Spell
    {
        public ProclamationOfDeath() : base("Proclamation of Death", 4, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.OpponentSacrificeEffect());
        }
    }
}
