using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class Seamine : Creature
    {
        public Seamine() : base("Seamine", 6, Common.Civilization.Water, 4000, Common.Subtype.Fish)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
