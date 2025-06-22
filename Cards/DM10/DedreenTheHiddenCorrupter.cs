using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10
{
    sealed class DedreenTheHiddenCorrupter : Engine.Creature
    {
        public DedreenTheHiddenCorrupter() : base("Dedreen, the Hidden Corrupter", 5, 4000, Interfaces.Race.PandorasBox, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new DedreenTheHiddenCorrupterAbility(3, new OpponentRandomDiscardEffect()));
        }
    }
}
