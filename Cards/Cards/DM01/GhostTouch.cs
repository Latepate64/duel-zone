using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class GhostTouch : Spell
    {
        public GhostTouch() : base("Ghost Touch", 2, Common.Civilization.Darkness)
        {
            ShieldTrigger = true;
            // Your opponent discards a card at random from his hand.
            AddSpellAbilities(new OpponentRandomDiscardEffect());
        }
    }
}
