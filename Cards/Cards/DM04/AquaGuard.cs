namespace Cards.Cards.DM04
{
    class AquaGuard : Creature
    {
        public AquaGuard() : base("Aqua Guard", 1, 2000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
