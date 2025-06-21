using TriggeredAbilities;

namespace Cards.DM11
{
    class LuckyBall : Engine.Creature
    {
        public LuckyBall() : base("Lucky Ball", 4, 3000, Interfaces.Race.CyberVirus, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new DedreenTheHiddenCorrupterAbility(3, new OneShotEffects.YouMayDrawUpToTwoCardsEffect()));
        }
    }
}
