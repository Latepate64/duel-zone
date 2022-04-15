namespace Cards.Cards.DM06
{
    class ParadiseHorn : Creature
    {
        public ParadiseHorn() : base("Paradise Horn", 4, 3000, Engine.Subtype.HornedBeast, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
