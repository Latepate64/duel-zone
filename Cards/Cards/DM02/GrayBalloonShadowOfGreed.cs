namespace Cards.Cards.DM02
{
    class GrayBalloonShadowOfGreed : Creature
    {
        public GrayBalloonShadowOfGreed() : base("Gray Balloon, Shadow of Greed", 3, 3000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
