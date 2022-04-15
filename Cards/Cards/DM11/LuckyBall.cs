using Common;

namespace Cards.Cards.DM11
{
    class LuckyBall : Creature
    {
        public LuckyBall() : base("Lucky Ball", 4, 3000, Engine.Subtype.CyberVirus, Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.DedreenTheHiddenCorrupterAbility(3, new OneShotEffects.YouMayDrawCardsEffect(2)));
        }
    }
}
