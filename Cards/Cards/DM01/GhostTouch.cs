using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class GhostTouch : Spell
    {
        public GhostTouch() : base("Ghost Touch", 2, Common.Civilization.Darkness)
        {
            ShieldTrigger = true;
            // Your opponent discards a card at random from his hand.
            Abilities.Add(new SpellAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
