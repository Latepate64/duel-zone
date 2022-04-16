namespace Cards.Cards.Promo
{
    class AngryMaple : Creature
    {
        public AngryMaple() : base("Angry Maple", 3, 1000, Engine.Race.TreeFolk, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(4000);
        }
    }
}
