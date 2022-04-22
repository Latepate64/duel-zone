using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class GhostTouch : Spell
    {
        public GhostTouch() : base("Ghost Touch", 2, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OpponentDiscardsCardAtRandomEffect());
        }
    }
}
