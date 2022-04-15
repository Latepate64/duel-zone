namespace Cards.Cards.DM03
{
    class BoltailDragon : Creature
    {
        public BoltailDragon() : base("Boltail Dragon", 7, 9000, Engine.Subtype.ArmoredDragon, Common.Civilization.Fire)
        {
            AddDoubleBreakerAbility();
        }
    }
}
