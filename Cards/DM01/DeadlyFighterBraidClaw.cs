namespace Cards.DM01
{
    class DeadlyFighterBraidClaw : Engine.Creature
    {
        public DeadlyFighterBraidClaw() : base("Deadly Fighter Braid Claw", 1, 1000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureAttacksEachTurnIfAbleEffect());
        }
    }
}
