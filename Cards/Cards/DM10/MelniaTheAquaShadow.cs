using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM10
{
    class MelniaTheAquaShadow : Creature
    {
        public MelniaTheAquaShadow() : base("Melnia, the Aqua Shadow", 2, 1000)
        {
            AddCivilizations(Civilization.Water, Civilization.Darkness);
            AddSubtypes(Subtype.LiquidPeople, Subtype.Ghost);
            AddAbilities(new UnblockableAbility(), new SlayerAbility());
        }
    }
}
