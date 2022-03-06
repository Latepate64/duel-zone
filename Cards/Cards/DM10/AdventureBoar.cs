using Common;

namespace Cards.Cards.DM10
{
    class AdventureBoar : Creature
    {
        public AdventureBoar() : base("Adventure Boar", 2, 1000, Subtype.BeastFolk, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.PowerAttackerAbility(2000));
        }
    }
}
