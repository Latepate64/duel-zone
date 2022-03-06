namespace Cards.Cards.DM03
{
    class BoltailDragon : Creature
    {
        public BoltailDragon() : base("Boltail Dragon", 7, 9000, Common.Subtype.ArmoredDragon, Common.Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
