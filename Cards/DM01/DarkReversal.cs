namespace Cards.DM01
{
    class DarkReversal : Engine.Spell
    {
        public DarkReversal() : base("Dark Reversal", 2, Interfaces.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnCreatureFromYourGraveyardToYourHandEffect());
        }
    }
}
