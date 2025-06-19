using Abilities.Triggered;

namespace Cards.Cards.DM10
{
    class DedreenTheHiddenCorrupter : Engine.Creature
    {
        public DedreenTheHiddenCorrupter() : base("Dedreen, the Hidden Corrupter", 5, 4000, Engine.Race.PandorasBox, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new DedreenTheHiddenCorrupterAbility(3, new OneShotEffects.OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
