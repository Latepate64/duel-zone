using Common;

namespace Cards.Cards.DM10
{
    class MelniaTheAquaShadow : Creature
    {
        public MelniaTheAquaShadow() : base("Melnia, the Aqua Shadow", 2, 1000, Civilization.Water, Civilization.Darkness)
        {
            AddSubtypes(Subtype.LiquidPeople, Subtype.Ghost);
            AddThisCreatureCannotBeBlockedAbility();
            AddSlayerAbility();
        }
    }
}
