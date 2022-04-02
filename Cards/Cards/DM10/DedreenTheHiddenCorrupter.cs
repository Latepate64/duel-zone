using Common;

namespace Cards.Cards.DM10
{
    class DedreenTheHiddenCorrupter : Creature
    {
        public DedreenTheHiddenCorrupter() : base("Dedreen, the Hidden Corrupter", 5, 4000, Subtype.PandorasBox, Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.DedreenTheHiddenCorrupterAbility(new OneShotEffects.OpponentRandomDiscardEffect()));
        }
    }
}
