namespace Cards.Cards.DM04
{
    public class Torcon : Creature
    {
        public Torcon() : base("Torcon", 2, Common.Civilization.Nature, 1000, Common.Subtype.BeastFolk)
        {
            ShieldTrigger = true;
        }
    }
}
