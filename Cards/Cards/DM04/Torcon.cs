namespace Cards.Cards.DM04
{
    class Torcon : Creature
    {
        public Torcon() : base("Torcon", 2, 1000, Common.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            ShieldTrigger = true;
        }
    }
}
