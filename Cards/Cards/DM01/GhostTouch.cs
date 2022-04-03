using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class GhostTouch : Spell
    {
        public GhostTouch() : base("Ghost Touch", 2, Common.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OpponentRandomDiscardEffect());
        }
    }
}
