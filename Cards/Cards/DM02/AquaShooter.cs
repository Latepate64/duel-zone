namespace Cards.Cards.DM02
{
    class AquaShooter : Creature
    {
        public AquaShooter() : base("Aqua Shooter", 4, 2000, Engine.Subtype.LiquidPeople, Engine.Civilization.Water)
        {
            AddBlockerAbility();
        }
    }
}
