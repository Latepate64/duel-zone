using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class Seamine : Creature
    {
        public Seamine() : base("Seamine", 6, 4000, Common.Subtype.Fish, Common.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
        }
    }
}
