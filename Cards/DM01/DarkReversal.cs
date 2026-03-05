namespace Cards.DM01
{
    sealed class DarkReversal : Spell
    {
        public DarkReversal() : base("Dark Reversal", 2, Interfaces.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnCreatureFromYourGraveyardToYourHandEffect());
        }
    }
}
