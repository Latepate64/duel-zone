using Common;

namespace Cards.Cards.DM06
{
    class PromephiusQ : Creature
    {
        public PromephiusQ() : base("Promephius Q", 3, 2000, Civilization.Water)
        {
            AddSubtypes(Subtype.Survivor, Subtype.SeaHacker);
        }
    }
}
