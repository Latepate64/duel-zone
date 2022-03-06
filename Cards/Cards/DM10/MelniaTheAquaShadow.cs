using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM10
{
    public class MelniaTheAquaShadow : Creature
    {
        public MelniaTheAquaShadow() : base("Melnia, the Aqua Shadow", 2, 1000)
        {
            Civilizations.Add(Civilization.Water);
            Civilizations.Add(Civilization.Darkness);
            Subtypes.Add(Subtype.LiquidPeople);
            Subtypes.Add(Subtype.Ghost);

            Abilities.Add(new UnblockableAbility());
            Abilities.Add(new SlayerAbility());
        }
    }
}
