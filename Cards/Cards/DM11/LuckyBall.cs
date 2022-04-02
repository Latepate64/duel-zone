using Common;

namespace Cards.Cards.DM11
{
    class LuckyBall : Creature
    {
        public LuckyBall() : base("Lucky Ball", 4, 3000, Subtype.CyberVirus, Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.DedreenTheHiddenCorrupterAbility(new OneShotEffects.YouMayDrawCardsEffect(2)));
        }
    }
}
