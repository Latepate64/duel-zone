using OneShotEffects;

namespace Cards.DM01
{
    sealed class GhostTouch : Engine.Spell
    {
        public GhostTouch() : base("Ghost Touch", 2, Interfaces.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OpponentRandomDiscardEffect());
        }
    }
}
