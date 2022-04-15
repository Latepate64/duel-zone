using Common;

namespace Cards.Cards.DM10
{
    class AdventureBoar : Creature
    {
        public AdventureBoar() : base("Adventure Boar", 2, 1000, Engine.Subtype.BeastFolk, Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
