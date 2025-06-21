namespace Cards.DM06
{
    class ProclamationOfDeath : Engine.Spell
    {
        public ProclamationOfDeath() : base("Proclamation of Death", 4, Interfaces.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.OpponentSacrificeEffect());
        }
    }
}
