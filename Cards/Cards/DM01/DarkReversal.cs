using Common;

namespace Cards.Cards.DM01
{
    class DarkReversal : Spell
    {
        public DarkReversal() : base("Dark Reversal", 2, Civilization.Darkness)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.ReturnCreatureFromYourGraveyardToYourHandEffect());
        }
    }
}
