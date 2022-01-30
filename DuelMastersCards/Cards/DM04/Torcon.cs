using Engine;

namespace Cards.Cards.DM04
{
    public class Torcon : Creature
    {
        public Torcon() : base("Torcon", 2, Civilization.Nature, 1000, Subtype.BeastFolk)
        {
            ShieldTrigger = true;
        }
    }
}
