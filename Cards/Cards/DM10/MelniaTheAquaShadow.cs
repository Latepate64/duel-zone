using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM10
{
    public class MelniaTheAquaShadow : Creature
    {
        public MelniaTheAquaShadow() : base("Melnia, the Aqua Shadow", 2, 1000)
        {
            AddCivilizations(Civilization.Water, Civilization.Darkness);
            AddSubtypes(Subtype.LiquidPeople, Subtype.Ghost);

            Abilities.Add(new UnblockableAbility());
            Abilities.Add(new SlayerAbility());
        }
    }
}
