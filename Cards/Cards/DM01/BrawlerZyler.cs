namespace Cards.Cards.DM01
{
    class BrawlerZyler : Creature
    {
        public BrawlerZyler() : base("Brawler Zyler", 2, 1000, Common.Subtype.Human, Common.Civilization.Fire)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
