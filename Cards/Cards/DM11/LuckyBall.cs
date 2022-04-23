namespace Cards.Cards.DM11
{
    class LuckyBall : Creature
    {
        public LuckyBall() : base("Lucky Ball", 4, 3000, Engine.Race.CyberVirus, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.DedreenTheHiddenCorrupterAbility(3, new OneShotEffects.YouMayDrawUpToTwoCardsEffect()));
        }
    }
}
