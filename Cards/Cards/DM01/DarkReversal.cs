namespace Cards.Cards.DM01
{
    class DarkReversal : Engine.Spell
    {
        public DarkReversal() : base("Dark Reversal", 2, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnCreatureFromYourGraveyardToYourHandEffect());
        }
    }
}
