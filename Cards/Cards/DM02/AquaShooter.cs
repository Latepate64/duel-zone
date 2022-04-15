namespace Cards.Cards.DM02
{
    class AquaShooter : Creature
    {
        public AquaShooter() : base("Aqua Shooter", 4, 2000, Engine.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            AddBlockerAbility();
        }
    }
}
